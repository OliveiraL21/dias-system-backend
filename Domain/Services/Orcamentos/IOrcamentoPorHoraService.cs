using Domain.Dtos.Orcamentos.PorHora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Orcamentos
{
    public interface IOrcamentoPorHoraService
    {
        Task<OrcamentoHoraDto> GetByIdAsync(Guid id);
        Task<IEnumerable<OrcamentoHoraDto>> FiltrarAsync(int? numero, Guid? clienteId);
        Task<IEnumerable<OrcamentoHoraDto>> GetAllAsync();
        Task<OrcamentoHoraDtoCreateResult> CreateAsync(OrcamentoHoraDtoCreate orcamento);
        Task<OrcamentoHoraDtoUpdateResult> UpdateAsync(Guid id, OrcamentoHoraDtoUpdate orcamento);
        Task<bool> DeleteAsync(Guid id);
    }
}
