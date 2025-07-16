using AutoMapper;
using Domain.Dtos.Empresa;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
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
        private readonly IEmpresaRepository _repository;
        private readonly IMapper _mapper;
        public EmpresaService(IEmpresaRepository repository, IMapper mapper)
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

        public async Task<IEnumerable<EmpresaDto>> FiltrarAsync(string razaoSocial, string cpf)
        {
            return _mapper.Map<IEnumerable<EmpresaDto>>(await _repository.FiltrarAsync(razaoSocial, cpf));
        }

        public async Task<IEnumerable<EmpresaDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmpresaDto>>(await _repository.GetAllWithRelationships());
        }

        public async Task<EmpresaDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EmpresaDto>(await _repository.GetWithRealationship(id));
        }

        public async Task<EmpresaDtoUpdateResult> UpdateAsync(Guid id, EmpresaDtoUpdate empresa)
        {
            var model = _mapper.Map<EmpresaModel>(empresa);
            var entity = _mapper.Map<EmpresaEntity>(model);
            return _mapper.Map<EmpresaDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
