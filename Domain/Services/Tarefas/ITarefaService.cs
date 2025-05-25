using Domain.Dtos.dashboard;
using Domain.Dtos.tarefas;
using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Tarefas
{
    public interface ITarefaService 
    {
        Task<TarefaDtoCreateResult> InsertAsync(TarefaDtoCreate tarefa);
        Task<TarefaDto> SelectAsync(Guid id);
        Task<TarefaDtoUpdateResult> UpdateAsync(Guid id, TarefaDtoUpdate tarefa);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<TarefaDto>> FiltrarAsync(string descricao, string dataInicio, string dataFim, Guid? projetoId);
        Task<string> calcularHorasTotaisAsync(DateTime data);
        Task<IEnumerable<TarefaDto>> ListaAsync();
        Task<DashboardDtoResult> ListaByProjetoAsync(Guid projeto);
        Task<object>calcularDuracao(string horarioInicio, string horarioFim);
    }
}
