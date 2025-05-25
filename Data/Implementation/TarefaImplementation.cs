using Data.Context;
using Data.Repository;
using Domain.Entidades;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Dtos.dashboard;


namespace Data.Implementation
{
    public class TarefaImplementation : BaseRepository<TarefaEntity>, ITarefaRepository
    {
        private DbSet<TarefaEntity> _dataSet;
        public TarefaImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<TarefaEntity>();
        }

        public async Task<string> calcularHorasTotaisAsync(DateTime data)
        {
            try
            {
                var tarefas = _dataSet.Where(x => x.Data == data).ToList();
                if (tarefas.Any())
                {
                    var duracao = new TimeSpan();

                    foreach (var tarefa in tarefas)
                    {
                        var hora = Convert.ToDateTime(tarefa.Duracao).TimeOfDay;
                        duracao += hora;
                    }
                    return duracao.ToString();
                }
                return "";
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TarefaEntity>> FiltrarAsync(string descricao, string dataInicio, string dataFim, Guid? projetoId)
        {
            try
            {
                var dataInicial = dataInicio == "null" ? null : dataInicio;
                var dataFinal = dataFim == "null" ? null : dataFim;
                var Descricao = descricao == "null" ? null : descricao;

                var result = _dataSet.Include(s => s.Status).Include(p => p.Projeto).AsQueryable();

                if (!string.IsNullOrEmpty(descricao))
                {
                    result = result.Where(t => t.Descricao.Equals(descricao));
                }

                if (dataInicial != null && dataFim != null)
                {
                    result = result.Where(t => t.Data >= Convert.ToDateTime(dataInicial) && t.Data <= Convert.ToDateTime(dataFinal));
                }

                if (projetoId != Guid.Empty)
                {
                    result = result.Where(t => t.ProjetoId == projetoId);
                }

                return await result.ToListAsync();
            }
            catch
            {
                throw;
            }
           
        }

        public async Task<IEnumerable<TarefaEntity>> GetAllAsync()
        {
            try
            {
                var result = await _dataSet.Include(x => x.Projeto).Include(x => x.Status).ToListAsync();
                foreach (var tarefa in result)
                {
                    tarefa.HorarioInicio = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(tarefa.HorarioInicio), "E. South America Standard Time");
                    tarefa.HorarioFim = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(tarefa.HorarioFim), "E. South America Standard Time");
                }
                return result;
            } catch
            {
                throw;
            }
        }

        private double SomarHoras(DashboardDtoResult dashboardEntity)
        {
            if (dashboardEntity == null)
            {
                return 0;
            }

            var total = dashboardEntity.Segunda + dashboardEntity.Terca + dashboardEntity.Quarta + dashboardEntity.Quinta + dashboardEntity.Sexta + dashboardEntity.Sabado
               + dashboardEntity.Domingo;

            return total;
        }

        public async Task<DashboardDtoResult> ListByProjetoAsync(Guid? projeto)
        {
            var today = DateTime.Now;

            var dayWeek = today.DayOfWeek;

            var result = new DashboardDtoResult();

            var tarefas = new List<TarefaEntity>();

            switch (dayWeek)
            {
                case DayOfWeek.Monday:
                    var tempData = today.AddDays(6);
                    var dataFim = new DateTime(tempData.Year, tempData.Month, tempData.Day, 0, 0, 0);
                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= new DateTime(today.Year, today.Month, today.Day, 0, 0, 0) && tarefa.Data <= dataFim).ToList();
                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(2)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(3)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(4)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(5)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(6)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;

                case DayOfWeek.Tuesday:
                    var tempIniTerca = today.AddDays(-1);
                    var dataInicialTerca = new DateTime(tempIniTerca.Year, tempIniTerca.Month, tempIniTerca.Day, 0, 0, 0);
                    var tempDataTerca = today.AddDays(6);
                    var dataFimTerca = new DateTime(tempDataTerca.Year, tempDataTerca.Month, tempDataTerca.Day, 0, 0, 0);

                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= dataInicialTerca && tarefa.Data <= dataFimTerca).ToList();
                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-1)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(2)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(3)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(4)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(5)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;

                case DayOfWeek.Wednesday:
                    var tempIniQuarta = today.AddDays(-2);
                    var dataInicialQuarta = new DateTime(tempIniQuarta.Year, tempIniQuarta.Month, tempIniQuarta.Day, 0, 0, 0);
                    var tempDataQuarta = today.AddDays(4);
                    var dataFimQuarta = new DateTime(tempDataQuarta.Year, tempDataQuarta.Month, tempDataQuarta.Day, 0, 0, 0);
                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= dataInicialQuarta && tarefa.Data <= dataFimQuarta).ToList();

                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-2)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-1)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(2)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(3)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(4)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;

                case DayOfWeek.Thursday:
                    var tempIniQuinta = today.AddDays(-3);
                    var dataInicioQuinta = new DateTime(tempIniQuinta.Year, tempIniQuinta.Month, tempIniQuinta.Day, 0, 0, 0);

                    var tempDataQuinta = today.AddDays(3);
                    var dataFimQuinta = new DateTime(tempDataQuinta.Year, tempDataQuinta.Month, tempDataQuinta.Day, 0, 0, 0);

                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= dataInicioQuinta && tarefa.Data <= dataFimQuinta).ToList();

                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-3)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-2)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-1)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(2)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(3)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;

                case DayOfWeek.Friday:

                    var tempIniSexta = today.AddDays(-4);
                    var dataInicioSexta = new DateTime(tempIniSexta.Year, tempIniSexta.Month, tempIniSexta.Day, 0, 0, 0);

                    var tempDataSexta = today.AddDays(2);
                    var dataFimSexta = new DateTime(tempDataSexta.Year, tempDataSexta.Month, tempDataSexta.Day, 0, 0, 0);

                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= dataInicioSexta && tarefa.Data <= dataFimSexta).ToList();

                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-4)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-3)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-2)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-1)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(2)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;

                case DayOfWeek.Saturday:

                    var tempIniSabado = today.AddDays(-5);
                    var dataInicioSabado = new DateTime(tempIniSabado.Year, tempIniSabado.Month, tempIniSabado.Day, 0, 0, 0);

                    var tempDataSabado = today.AddDays(1);
                    var dataFimSabado = new DateTime(tempDataSabado.Year, tempDataSabado.Month, tempDataSabado.Day, 0, 0, 0);

                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= dataInicioSabado && tarefa.Data <= dataFimSabado).ToList();

                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-5)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-4)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-3)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-2)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-1)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(1)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;

                case DayOfWeek.Sunday:

                    var tempIniDomingo = today.AddDays(-6);
                    var dataInicioDomingo = new DateTime(tempIniDomingo.Year, tempIniDomingo.Month, tempIniDomingo.Day, 0, 0, 0);

                    var tempDataDomingo = today;
                    var dataFimDomingo = new DateTime(tempDataDomingo.Year, tempDataDomingo.Month, tempDataDomingo.Day, 0, 0, 0);

                    tarefas = _dataSet.Where(tarefa => tarefa.ProjetoId == projeto && tarefa.Data >= dataInicioDomingo && tarefa.Data <= dataFimDomingo).ToList();

                    result.Segunda = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-6)).Sum(x => x.Duracao.Hour);
                    result.Terca = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-5)).Sum(x => x.Duracao.Hour);
                    result.Quarta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-4)).Sum(x => x.Duracao.Hour);
                    result.Quinta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-3)).Sum(x => x.Duracao.Hour);
                    result.Sexta = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-2)).Sum(x => x.Duracao.Hour);
                    result.Sabado = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0).AddDays(-1)).Sum(x => x.Duracao.Hour);
                    result.Domingo = tarefas.Where(r => r.Data == new DateTime(today.Year, today.Month, today.Day, 0, 0, 0)).Sum(x => x.Duracao.Hour);
                    result.TotalHoras = SomarHoras(result);
                    break;
            }

            return result;
        }
    }
}
