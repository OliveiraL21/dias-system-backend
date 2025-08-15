using Domain.Dtos.dashboard;
using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITarefaRepository : IRepository<TarefaEntity>
    {
        Task<string> calcularHorasTotaisAsync(DateTime data);
        Task<IEnumerable<TarefaEntity>> FiltrarAsync(string descricao, string dataInicio, string dataFim, Guid? projetoId, Guid? statusId);
        Task<IEnumerable<TarefaEntity>> GetAllAsync();
        Task<IEnumerable<TarefaEntity>> GetAllByProjectAsync(Guid projeto);
        Task<int> GetTotalTarefasByProjectAsync();
        Task<DashboardDtoResult>ListByProjetoDashboardAsync(Guid? projeto);
        Task<IEnumerable<TarefaEntity>>GetAllByProjectWithRangeAsync(Guid projetoId, DateTime dataInicio, DateTime dataFim);

    }
}
