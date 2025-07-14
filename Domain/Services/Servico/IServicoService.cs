using Domain.Dtos.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Servico
{
    public interface IServicoService
    {
        Task<ServicoDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ServicoDto>> GetAllAsync();
        Task<ServicoDtoCreateResult> CreateAsync(ServicoDtoCreate servico);
        Task<ServicoDtoUpdateResult> UpdateAsync(Guid id, ServicoDtoUpdate servico);
        Task<bool> DeleteAsync(Guid id);
    }
}
