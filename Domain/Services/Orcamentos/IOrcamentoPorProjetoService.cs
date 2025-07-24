using Domain.Dtos.Orcamentos.PorProjeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Orcamentos
{
    public interface IOrcamentoPorProjetoService
    {
        Task<OrcamentoPorProjetoDto> GetByIdAsync(Guid id);
        Task<IEnumerable<OrcamentoPorProjetoDtoList>> GetAllAsync();
        Task<IEnumerable<OrcamentoPorProjetoDtoList>> FiltrarAsync(int? numero, Guid cliente);
        Task<OrcamentoPorProjetoDtoCreateResult> CreateAsync(OrcamentoPorProjetoDtoCreate orcamento);
        Task<OrcamentoPorProjetoDtoUpdateResult> UpdateAsync(Guid id, OrcamentoPorProjetoDtoUpdate orcamento);
        Task<bool> DeleteAsync(Guid id);
      

    }
}
