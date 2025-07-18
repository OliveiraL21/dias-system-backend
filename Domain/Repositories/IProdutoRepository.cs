using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProdutoRepository : IRepository<ProdutoEntity>
    {
        Task<IEnumerable<ProdutoEntity>> Filtrar(string descricao);
    }
}
