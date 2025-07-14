using AutoMapper;
using Domain.Dtos.Empresa;
using Domain.Entidades;
using Domain.Models;
using Domain.Repository;
using Domain.Services.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Empresa
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRepository<EmpresaEntity> _repository;
        private readonly IMapper _mapper;
        public EmpresaService(IRepository<EmpresaEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EmpresaDtoCreateResult> CreateAsync(EmpresaDtoCreate empresa)
        {
            var model = _mapper.Map<EmpresaModel>(empresa);
            var entity = _mapper.Map<EmpresaEntity>(model);
            return _mapper.Map<EmpresaDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmpresaDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmpresaDto>>(await _repository.SelectAllAsync());
        }

        public async Task<EmpresaDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EmpresaDto>(await _repository.SelectAsync(id));
        }

        public async Task<EmpresaDtoUpdateResult> UpdateAsync(Guid id, EmpresaDtoUpdate empresa)
        {
            var model = _mapper.Map<EmpresaModel>(empresa);
            var entity = _mapper.Map<EmpresaEntity>(model);
            return _mapper.Map<EmpresaDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
