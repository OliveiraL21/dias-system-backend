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
    public class OrcamentoPorProjetoImplementation : BaseRepository<OrcamentoPorProjetoEntity>, IOrcamentoPorProjetoRepository
    {
        private readonly  DbSet<OrcamentoPorProjetoEntity> _dataSet;
        public OrcamentoPorProjetoImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<OrcamentoPorProjetoEntity>();
        }

        public async Task<IEnumerable<OrcamentoPorProjetoEntity>> GetAllWithRelationships()
        {
            try
            {
                var result = await _dataSet.Include(x => x.Empresa).Include(x => x.Cliente).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            };

        }
        public async Task<OrcamentoPorProjetoEntity> GetByIdWithRelationships(Guid id)
        {
            try
            {
                var result = await _dataSet.Include(x => x.Empresa).Include(x => x.Cliente).FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            ;
        }
    }
}
