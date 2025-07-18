using Domain.Dtos.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Produto
{
    public interface IProdutoService
    {
        Task<ProdutoDto> GetbyIdAsync(Guid id);
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<IEnumerable<ProdutoDto>> FiltrarAsync(string descricao);
        Task<ProdutoDtoCreateResult> CreateAsync(ProdutoDtoCreate produto);
        Task<ProdutoDtoUpdateResult>UpdateAsync(Guid id, ProdutoDtoUpdate produto);
        Task<bool> DeleteAsync(Guid id);
    }
}
