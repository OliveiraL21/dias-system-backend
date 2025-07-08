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

        private double CalcularTotalDeHorasDoProjeto(IEnumerable<TarefaEntity> tarefas)
        {
            TimeSpan totalHora = TimeSpan.Zero;
            foreach(var tarefa in tarefas)
            {
                totalHora += tarefa.Duracao.TimeOfDay;
            }
            
            return totalHora.TotalHours;
        }

        private double CalcularValorTotalDoProjeto(double totalHoras)
        {
            if (totalHoras > 0)
            {
                double total = 0;
                total = totalHoras * 50;
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
                projeto.ValorTotalProjeto = CalcularValorTotalDoProjeto(projeto.TotalHoras ?? 0);

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
