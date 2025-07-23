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

        private async Task<int> gerarNumeroDoOrcamento()
        {
            return await _repository.GetLastOrcamentoNumber();
        }

        private double CalcularValorTotalDoOrcamento(OrcamentoPorProjetoEntity orcamento)
        {
            double total = 0;
            foreach(var produto in orcamento.Produtos)
            {
                total += produto.ValorTotalVenda;
            }

            return total;
        }

        public async Task<OrcamentoPorProjetoDtoCreateResult> CreateAsync(OrcamentoPorProjetoDtoCreate orcamento)
        {
            var model = _mapper.Map<OrcamentoPorProjetoModel>(orcamento);
            var entity = _mapper.Map<OrcamentoPorProjetoEntity>(model);
            entity.Numero = await gerarNumeroDoOrcamento();
            entity.ValorTotal = CalcularValorTotalDoOrcamento(entity);

            return _mapper.Map<OrcamentoPorProjetoDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrcamentoPorProjetoDto>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<IEnumerable<OrcamentoPorProjetoDto>>(await _repository.GetAllWithRelationships());
            }
            catch (AutoMapperMappingException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                throw;
            }
           
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
