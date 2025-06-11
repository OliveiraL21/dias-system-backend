using Data.Context;
using Data.Repository;
using Domain.Dtos.cliente;
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
    public class ProjetoImplementation : BaseRepository<ProjetoEntity>, IProjetoRepository
    {
        private DbSet<ProjetoEntity> _dataSet;
        public ProjetoImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ProjetoEntity>();
        }

        public async Task<ProjetoEntity> SelectProjectWithRealationShipsAsync(Guid id)
        {
            try
            {
                return await _dataSet.Include(p => p.Status).Include(p => p.Cliente).FirstOrDefaultAsync(p => p.Id == id);
            }
            catch
            {
                throw;
            }
        }

        async Task<IEnumerable<ProjetoEntity>> IProjetoRepository.FiltrarAsync(Guid? projeto, Guid? clienteId, Guid? statusId)
        {
            try
            {
                var result = _dataSet.Include(p => p.Cliente).Include(p => p.Status).AsQueryable();

                if ((!projeto.HasValue || projeto == Guid.Empty) && (!clienteId.HasValue || clienteId == Guid.Empty) &&
                (!statusId.HasValue || statusId == Guid.Empty))
                {
                    return await result.ToListAsync();
                }

                result = result.Where(p => p.Id == projeto || p.ClienteId == clienteId || p.StatusId == statusId);

                return await result.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        async Task<IEnumerable<ProjetoEntity>> IProjetoRepository.GetAll()
        {
            try
            {
                return await _dataSet.Include(p => p.Status).Include(p => p.Cliente).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
