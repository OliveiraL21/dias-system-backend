using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrcamentoPorProjetoRepository :IRepository<OrcamentoPorProjetoEntity>
    {
        Task<IEnumerable<OrcamentoPorProjetoEntity>> GetAllWithRelationships();
        Task<OrcamentoPorProjetoEntity> GetByIdWithRelationships(Guid id);
        Task<int> GetLastOrcamentoNumber();
        Task<bool> CreateProdutoOrcamento(ProdutoOrcamentoProjetoEntity orcamento);
        Task<IEnumerable<OrcamentoPorProjetoEntity>> Filtrar(int? numero, Guid cliente);

    }
}
