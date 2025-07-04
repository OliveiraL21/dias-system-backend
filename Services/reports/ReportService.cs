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
        public ReportService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<Stream> ServicosPrestados(Guid projetoId)
        {
            try
            {
                var projeto = await _projetoRepository.SelectProjectWithRealationShipsAsync(projetoId);
                var webReport = new WebReport();
                webReport.Report.Load(Path.Combine("reports\\relatorio-servicos-prestados.frx"));
                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(Guid));
                dataTable.Columns.Add("Descricao", typeof(string));
                dataTable.Columns.Add("DataInicio", typeof(DateTime));
                dataTable.Columns.Add("RazaoSocial", typeof(string));
                dataTable.Columns.Add("Telefone", typeof(string));
                dataTable.Columns.Add("Cnpj", typeof(string));
                dataTable.Columns.Add("Logradouro", typeof(string));
                dataTable.Columns.Add("Numero", typeof(string));
                dataTable.Columns.Add("Bairro", typeof(string));
                dataTable.Columns.Add("Cidade", typeof(string));

                webReport.Report.Prepare();
                foreach (var tarefa in projeto.Tarefas)
                {
                    dataTable.Rows.Add(
                        tarefa.Id,
                        tarefa.Descricao,
                        tarefa.Data,
                        tarefa.Duracao
                    );
                }
                webReport.Report.RegisterData(projeto.Tarefas, "Tarefas");

                using (MemoryStream ms = new MemoryStream())
                {
                    var pdfExport = new PDFSimpleExport();
                    pdfExport.Export(webReport.Report, ms);
                    ms.Flush();
                    return ms;
                }


            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
