using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IServicoRepository : IRepository<ServicoEntity>
    {
        Task<IEnumerable<ServicoEntity>> GetAllWithRelationships();
        Task<ServicoEntity> GetByIdWithRelationships(Guid id);
    }
}
