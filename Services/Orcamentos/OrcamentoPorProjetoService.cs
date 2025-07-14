using AutoMapper;
using Domain.Dtos.Orcamentos.PorHora;
using Domain.Dtos.Orcamentos.PorProjeto;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Services.Orcamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orcamentos
{
    public class OrcamentoPorProjetoService : IOrcamentoPorProjetoService
    {
        private readonly IOrcamentoPorProjetoRepository _repository;
        private readonly IMapper _mapper;
        public OrcamentoPorProjetoService(IOrcamentoPorProjetoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrcamentoPorProjetoDtoCreateResult> CreateAsync(OrcamentoPorProjetoDtoCreate orcamento)
        {
            var model = _mapper.Map<OrcamentoPorProjetoModel>(orcamento);
            var entity = _mapper.Map<OrcamentoPorProjetoEntity>(model);
            return _mapper.Map<OrcamentoPorProjetoDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrcamentoPorProjetoDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrcamentoPorProjetoDto>>(await _repository.GetAllWithRelationships());
        }

        public async Task<OrcamentoPorProjetoDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<OrcamentoPorProjetoDto>(await _repository.GetByIdWithRelationships(id));
        }

        public async Task<OrcamentoPorProjetoDtoUpdateResult> UpdateAsync(Guid id, OrcamentoPorProjetoDtoUpdate orcamento)
        {
            var model = _mapper.Map<OrcamentoPorProjetoModel>(orcamento);
            var entity = _mapper.Map<OrcamentoPorProjetoEntity>(model);
            return _mapper.Map<OrcamentoPorProjetoDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
