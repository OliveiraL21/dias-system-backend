using AutoMapper;
using Domain.Dtos.Orcamentos.PorHora;
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
    public class OrcamentoHoraService : IOrcamentoPorHoraService
    {
        private readonly IOrcamentoHoraRepository _repository;
        private readonly IMapper _mapper;
        public OrcamentoHoraService(IOrcamentoHoraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrcamentoHoraDtoCreateResult> CreateAsync(OrcamentoHoraDtoCreate orcamento)
        {
            var model = _mapper.Map<OrcamentoHoraModel>(orcamento);
            var entity = _mapper.Map<OrcamentoHoraEntity>(model);
            return _mapper.Map<OrcamentoHoraDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrcamentoHoraDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrcamentoHoraDto>>(await _repository.GetAllWithRelationships());
        }

        public async Task<OrcamentoHoraDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<OrcamentoHoraDto>(await _repository.GetByIdWithRelationships(id));
        }

        public async Task<OrcamentoHoraDtoUpdateResult> UpdateAsync(Guid id, OrcamentoHoraDtoUpdate orcamento)
        {
            var model = _mapper.Map<OrcamentoHoraModel>(orcamento);
            var entity = _mapper.Map<OrcamentoHoraEntity>(model);
            return _mapper.Map<OrcamentoHoraDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
