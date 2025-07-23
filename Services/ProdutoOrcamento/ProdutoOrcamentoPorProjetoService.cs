using AutoMapper;
using Domain.Dtos.ProdutoOrcamento;
using Domain.Entidades;
using Domain.Models;
using Domain.Repository;
using Domain.Services.ProdutoOrcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdutoOrcamento
{
    public class ProdutoOrcamentoPorProjetoService : IProdutoOrcamentoPorProjetoService
    {
        private readonly IRepository<ProdutoOrcamentoProjetoEntity> _repository;
        private readonly IMapper _mapper;
        public ProdutoOrcamentoPorProjetoService(IRepository<ProdutoOrcamentoProjetoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProdutoOrcamentoProjetoDto> Create(ProdutoOrcamentoProjetoDtoCreate produto)
        {
            var model = _mapper.Map<ProdutoOrcamentoProjetoModel>(produto);
            var entity = _mapper.Map<ProdutoOrcamentoProjetoEntity>(model);
            return _mapper.Map<ProdutoOrcamentoProjetoDto>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProdutoOrcamentoProjetoDto> Get(Guid id)
        {
            return _mapper.Map<ProdutoOrcamentoProjetoDto>(await _repository.SelectAsync(id));
        }

        public async Task<IEnumerable<ProdutoOrcamentoProjetoDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoOrcamentoProjetoDto>>(await _repository.SelectAllAsync());
        }

        public async Task<ProdutoOrcamentoProjetoDto> Update(Guid id, ProdutoOrcamentoProjetoDtoUpdate produto)
        {
            var model = _mapper.Map<ProdutoOrcamentoProjetoModel>(produto);
            var entity = _mapper.Map<ProdutoOrcamentoProjetoEntity>(model);
            return _mapper.Map<ProdutoOrcamentoProjetoDto>(await _repository.UpdateAsync(id,entity));
        }
    }
}
