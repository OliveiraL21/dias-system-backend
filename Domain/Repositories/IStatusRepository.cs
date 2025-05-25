using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStatusRepository : IRepository<StatusEntity>
    {
        Task<IEnumerable<StatusEntity>>GetAllAsync();
    }
}
