using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrcamentoHoraRepository : IRepository<OrcamentoHoraEntity>
    {
        Task<IEnumerable<OrcamentoHoraEntity>> GetAllWithRelationships();
        Task<OrcamentoHoraEntity> GetByIdWithRelationships(Guid id);
    }
}
