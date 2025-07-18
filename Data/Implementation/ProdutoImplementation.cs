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
    public class ProdutoImplementation : BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        private readonly DbSet<ProdutoEntity> _dataSet;
        public ProdutoImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ProdutoEntity>();
        }

        public async Task<IEnumerable<ProdutoEntity>> Filtrar(string descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao))
                {
                    return await _dataSet.AsNoTracking().ToListAsync();
                }

                return await _dataSet.AsNoTracking().Where(x => EF.Functions.Like(x.Descricao, descricao)).ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
