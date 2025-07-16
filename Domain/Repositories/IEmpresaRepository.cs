using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmpresaRepository : IRepository<EmpresaEntity>
    {
        Task<IEnumerable<EmpresaEntity>> GetAllWithRelationships();
        Task<EmpresaEntity> GetWithRealationship(Guid id);
        Task<IEnumerable<EmpresaEntity>> FiltrarAsync(string razaoSocial, string cpf);
    }
}
