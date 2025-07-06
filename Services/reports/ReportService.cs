using Domain.Entidades;
using Domain.Repositories;
using Domain.Services.Report;
using FastReport.Export.PdfSimple;
using Services.Helpers;
using System;
using System.Collections.Generic;
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

        private DateTime CalcularTotalDeHorasDoProjeto(IEnumerable<TarefaEntity> tarefas)
        {
            DateTime total = new DateTime(2025, 01, 01, 0,0,0);
            foreach(var tarefa in tarefas)
            {
                total = total.AddHours(tarefa.Duracao.Hour);
            }
            return total;
        }

        private double CalcularValorTotalDoProjeto(DateTime? totalHoras)
        {
            if (totalHoras.HasValue)
            {
                var total = 0;
                total = totalHoras.Value.Hour * 50;
                return total;
            }
            return 0;
            
        }
        public async Task<byte[]> ServicosPrestados(Guid projetoId)
        {
            try
            {
                var projeto = await _projetoRepository.SelectProjectWithRealationShipsAsync(projetoId);
                var tarefas = await _tarefaRepository.GetAllByProjectAsync(projetoId);
                projeto.TotalHoras = CalcularTotalDeHorasDoProjeto(tarefas);
                projeto.ValorTotalProjeto = CalcularValorTotalDoProjeto(projeto.TotalHoras);

                var webReport = HelperFastReport.WebReport("relatorio-servicos-prestados.frx");

                List<ProjetoEntity> projetoList = [projeto];
                var projetoTable = HelperFastReport.GetTable<ProjetoEntity>(projetoList, "Projetos");

                List<ClienteEntity> ClienteList = [projeto.Cliente];
                var clienteTable = HelperFastReport.GetTable<ClienteEntity>(ClienteList, "Clientes");

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
