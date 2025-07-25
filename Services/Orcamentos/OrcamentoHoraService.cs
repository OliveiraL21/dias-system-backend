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

        private double CalcularValorTotalHora(OrcamentoHoraEntity orcamento)
        {
            if (orcamento is not null)
            {
                double total = 0;
                foreach(var servico in orcamento.Servicos)
                {
                    total += (Convert.ToDouble(servico.QuantidadeHora) * orcamento.ValorHora);
                }
                return total;
            }
            return 0;
        }

        public async Task<OrcamentoHoraDtoCreateResult> CreateAsync(OrcamentoHoraDtoCreate orcamento)
        {
            var model = _mapper.Map<OrcamentoHoraModel>(orcamento);
            var entity = _mapper.Map<OrcamentoHoraEntity>(model);
            foreach(var servico in entity.Servicos)
            {
                servico.Id = Guid.NewGuid();
                servico.CreateAt = DateTimeOffset.Now;
            }
            entity.ValorTotal = CalcularValorTotalHora(entity);
            entity.Numero = await _repository.GenerateOrcamentoNumber();
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
