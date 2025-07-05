using Domain.Entidades;
using Domain.Repositories;
using Domain.Services.Report;
using FastReport.Export.PdfSimple;
using Services.Helpers;
using System;
using System.Data;
using System.IO;
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

                var webReport = HelperFastReport.WebReport("relatorio-servicos-prestados.frx");

                var projetoTable = new DataTable();
                projetoTable.Columns.Add("Descricao", typeof(string));
                projetoTable.Columns.Add("DataInicio", typeof(DateTime));
                projetoTable.Columns.Add("DataFim", typeof(DateTime));
                projetoTable.Rows.Add(projeto.Descricao, projeto.DataInicio, projeto.DataFim);


                var clienteTable = new DataTable();
                clienteTable.Columns.Add("RazaoSocial", typeof(string));
                clienteTable.Columns.Add("Telefone", typeof(string));
                clienteTable.Columns.Add("Cnpj", typeof(string));
                clienteTable.Columns.Add("Logradouro", typeof(string));
                clienteTable.Columns.Add("Numero", typeof(string));
                clienteTable.Columns.Add("Bairro", typeof(string));
                clienteTable.Columns.Add("Cidade", typeof(string));

                clienteTable.Rows.Add(projeto.Cliente.RazaoSocial, projeto.Cliente.Telefone,string.IsNullOrEmpty(projeto.Cliente.Cnpj) ? projeto.Cliente.Cpf : projeto.Cliente.Cnpj, projeto.Cliente.Logradouro,
                    projeto.Cliente.Numero, projeto.Cliente.Bairro, projeto.Cliente.Cidade);

                var tarefasTable = HelperFastReport.GetTable<TarefaEntity>(tarefas, "Tarefas");


                webReport.Report.RegisterData(projetoTable, "Projetos");
                webReport.Report.RegisterData(clienteTable, "Clientes");
                webReport.Report.RegisterData(tarefasTable, "Tarefas");
                return HelperFastReport.ExportPdf(webReport);

              

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
