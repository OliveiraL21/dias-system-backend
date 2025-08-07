using AutoMapper;
using Domain.Dtos.Produto;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Repository;
using Domain.Services.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProdutoDtoCreateResult> CreateAsync(ProdutoDtoCreate produto)
        {
            var model = _mapper.Map<ProdutoModel>(produto);
            var entity = _mapper.Map<ProdutoEntity>(model);
            return _mapper.Map<ProdutoDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutoDto>> FiltrarAsync(string? descricao)
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>((await _repository.Filtrar(descricao)).OrderBy(x => x.Descricao));
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>((await _repository.SelectAllAsync()).OrderBy(x => x.Descricao));
        }

        public async Task<ProdutoDto> GetbyIdAsync(Guid id)
        {
            return _mapper.Map<ProdutoDto>(await _repository.SelectAsync(id));
        }

        public async Task<ProdutoDtoUpdateResult> UpdateAsync(Guid id, ProdutoDtoUpdate produto)
        {
            var model = _mapper.Map<ProdutoModel>(produto);
            var entity = _mapper.Map<ProdutoEntity>(model);
            return _mapper.Map<ProdutoDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
