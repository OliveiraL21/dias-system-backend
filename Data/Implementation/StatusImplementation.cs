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
    public class StatusImplementation : BaseRepository<StatusEntity>, IStatusRepository
    {
        private DbSet<StatusEntity> _dataSet;
        public StatusImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<StatusEntity>();
        }

        public async Task<IEnumerable<StatusEntity>> GetAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
