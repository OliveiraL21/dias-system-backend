using Domain.Dtos.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Empresa
{
    public interface IEmpresaService
    {
        Task<EmpresaDto> GetByIdAsync(Guid id);
        Task<IEnumerable<EmpresaDto>> GetAllAsync();
        Task<EmpresaDtoCreateResult> CreateAsync(EmpresaDtoCreate empresa);
        Task<EmpresaDtoUpdateResult> UpdateAsync(Guid id, EmpresaDtoUpdate empresa);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<EmpresaDto>> FiltrarAsync(string razaoSocial, string cpf);
    }
}
