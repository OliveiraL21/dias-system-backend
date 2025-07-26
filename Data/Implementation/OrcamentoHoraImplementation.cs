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
    public class OrcamentoHoraImplementation : BaseRepository<OrcamentoHoraEntity>, IOrcamentoHoraRepository
    {
        private readonly DbSet<OrcamentoHoraEntity> _dataSet;
        public OrcamentoHoraImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<OrcamentoHoraEntity>();
        }

        public async Task<int> GenerateOrcamentoNumber()
        {
            try
            {
                var result = await _dataSet.OrderBy(x => x.Numero).LastOrDefaultAsync();
                if(result is not null)
                {
                    return result.Numero + 1;
                }

                return 1000;

            } catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrcamentoHoraEntity>> GetAllWithRelationships()
        {
            try
            {
               var result = await _dataSet.Include(x => x.Empresa)
                    .Include(x => x.Cliente)
                    .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OrcamentoHoraEntity> GetByIdWithRelationships(Guid id)
        {
            try
            {
                var result = await _dataSet
                    .Include(x => x.Empresa)
                    .Include(x => x.Cliente)
                    .Include(x => x.Servicos)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
