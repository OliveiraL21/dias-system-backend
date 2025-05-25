using Domain.Dtos.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Status
{
    public interface IStatusService
    {
        Task<StatusDto> SelectAsync(Guid id);
        Task<StatusDtoCreateResult> InsertAsync(StatusDtoCreate statusDto);
        Task<StatusDtoUpdateResult> UpdateAsync(Guid id, StatusDtoUpdate statusDto);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<StatusDtoListagem>> ListaAsync();
    }
}
