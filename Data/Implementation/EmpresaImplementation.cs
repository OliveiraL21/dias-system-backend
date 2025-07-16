using Data.Context;
using Data.Repository;
using Domain.Entidades;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class EmpresaImplementation : BaseRepository<EmpresaEntity>, IEmpresaRepository
    {
        private readonly DbSet<EmpresaEntity> _dataSet;
        public EmpresaImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<EmpresaEntity>();
        }

        public async Task<IEnumerable<EmpresaEntity>> FiltrarAsync(string razaoSocial, string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(razaoSocial) && string.IsNullOrEmpty(cpf))
                {
                    return await _dataSet.Include(e => e.Status).ToListAsync();
                }

                return await _dataSet.AsNoTracking().Include(x => x.Status).Where(x => x.RazaoSocial.Equals(razaoSocial) || x.Cpf == cpf)
                    .ToListAsync();
            } catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmpresaEntity>> GetAllWithRelationships()
        {
            try
            {
                return await _dataSet.Include(e => e.Status).ToListAsync();
            } catch
            {
                throw;
            }
        }

        public async Task<EmpresaEntity> GetWithRealationship(Guid id)
        {
            try
            {
                return await _dataSet.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch 
            {
                throw;
            }
        }
    }
}
