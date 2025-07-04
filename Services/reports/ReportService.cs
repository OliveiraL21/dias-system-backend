using Domain.Repositories;
using Domain.Services.Report;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.reports
{
    public class ReportService : IReportService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;
        public ReportService(IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository)
        {
            _projetoRepository = projetoRepository;
            _tarefaRepository = tarefaRepository;
        }

        public async Task<byte[]> ServicosPrestados(Guid projetoId)
        {
            try
            {
                var projeto = await _projetoRepository.SelectProjectWithRealationShipsAsync(projetoId);
                var tarefas = await _tarefaRepository.GetAllByProjectAsync(projetoId);

                var webReport = new WebReport();
                webReport.Report.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"reports\\relatorio-servicos-prestados.frx"));
                var dataTableProjeto = new DataTable();

                dataTableProjeto.Columns.Add("Descricao", typeof(string));
                dataTableProjeto.Columns.Add("DataInicio", typeof(DateTime));
 
                dataTableProjeto.Rows.Add(projeto.Descricao, projeto.DataInicio);

                var dataTableCliente = new DataTable();
                dataTableCliente.Columns.Add("RazaoSocial", typeof(string));
                dataTableCliente.Columns.Add("Telefone", typeof(string));
                dataTableCliente.Columns.Add("Cnpj", typeof(string));
                dataTableCliente.Columns.Add("Logradouro", typeof(string));
                dataTableCliente.Columns.Add("Numero", typeof(string));
                dataTableCliente.Columns.Add("Bairro", typeof(string));
                dataTableCliente.Columns.Add("Cidade", typeof(string));

                dataTableCliente.Rows.Add(projeto.Cliente.RazaoSocial, projeto.Cliente.Telefone,string.IsNullOrEmpty(projeto.Cliente.Cnpj) ? projeto.Cliente.Cpf : projeto.Cliente.Cnpj, projeto.Cliente.Logradouro,
                    projeto.Cliente.Numero, projeto.Cliente.Bairro, projeto.Cliente.Cidade);

                var dataTableTarefas = new DataTable();
                dataTableTarefas.Columns.Add("Descricao", typeof(string));
                dataTableTarefas.Columns.Add("Data", typeof(DateTime));
                dataTableTarefas.Columns.Add("Duracao", typeof(DateTime));

                foreach(var tarefa in tarefas)
                {
                    dataTableTarefas.Rows.Add(tarefa.Descricao, tarefa.Data, tarefa.Duracao);
                }

                webReport.Report.RegisterData(dataTableProjeto, "Projetos");
                webReport.Report.RegisterData(dataTableCliente, "Clientes");
                webReport.Report.RegisterData(dataTableTarefas, "Tarefas");
                webReport.Report.Prepare();

                using (MemoryStream ms = new MemoryStream())
                {
                   var pdfExport = new PDFSimpleExport();
                   pdfExport.Export(webReport.Report, ms);
                   ms.Flush();
                   return ms.ToArray();
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
