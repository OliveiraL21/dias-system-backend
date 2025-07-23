using Domain.Dtos.ProdutoOrcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.ProdutoOrcamento
{
    public interface IProdutoOrcamentoPorProjetoService
    {
        Task<ProdutoOrcamentoProjetoDto> Create(ProdutoOrcamentoProjetoDtoCreate produto);
        Task<ProdutoOrcamentoProjetoDto> Get(Guid id);
        Task<ProdutoOrcamentoProjetoDto> Update(Guid id, ProdutoOrcamentoProjetoDtoUpdate produto);
        Task<IEnumerable<ProdutoOrcamentoProjetoDto>> GetAll();
        Task<bool> Delete(Guid id);
    }
}
