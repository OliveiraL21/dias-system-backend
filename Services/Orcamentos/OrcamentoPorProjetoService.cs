using AutoMapper;
using Domain.Dtos.Orcamentos.PorHora;
using Domain.Dtos.Orcamentos.PorProjeto;
using Domain.Dtos.ProdutoOrcamento;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Services.Orcamentos;
using Domain.Services.ProdutoOrcamento;
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
        private readonly IProdutoOrcamentoPorProjetoService _produtoService;
        
        public OrcamentoPorProjetoService(IOrcamentoPorProjetoRepository repository, IMapper mapper, IProdutoOrcamentoPorProjetoService produtoService)
        {
            _repository = repository;
            _produtoService = produtoService;
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

        public async Task<IEnumerable<OrcamentoPorProjetoDtoList>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<IEnumerable<OrcamentoPorProjetoDtoList>>(await _repository.GetAllWithRelationships());
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

        private async Task CreateProdutoOrcamento(OrcamentoPorProjetoEntity orcamento)
        {
            if(orcamento.Produtos != null)
            {
                var produtos = orcamento.Produtos.Where(x => x.Id == null || x.Id == Guid.Empty).ToList();
                foreach(var produto in produtos)
                {
                    await _repository.CreateProdutoOrcamento(produto);
                }
            }
        }

        public async Task<OrcamentoPorProjetoDtoUpdateResult> UpdateAsync(Guid id, OrcamentoPorProjetoDtoUpdate orcamento)
        {
            var model = _mapper.Map<OrcamentoPorProjetoModel>(orcamento);
            var entity = _mapper.Map<OrcamentoPorProjetoEntity>(model);

            //verificar se tem produto para ser criado.
            if (orcamento.Produtos.Where(x => x.Id == Guid.Empty || x.Id == null).ToList().Count >= 1)
            {
                await CreateProdutoOrcamento(entity);
            }

            foreach(var produto in orcamento.Produtos)
            {
                if(produto.Id == null || produto.Id == Guid.Empty)
                {
                    var produtoModel = _mapper.Map<ProdutoOrcamentoProjetoModel>(produto);
                    var produtoEntity = _mapper.Map<ProdutoOrcamentoProjetoEntity>(produtoModel);
                    var produtoCreateDto = _mapper.Map<ProdutoOrcamentoProjetoDtoCreate>(produtoEntity);
                    var produtoCreated = await _produtoService.Create(produtoCreateDto);
                }
                else
                {
                    var produtoResult = await _produtoService.Update(produto.Id ?? Guid.Empty, produto);
                }
                   
            }
            //recalcular o valor total do orçamento.
            entity.ValorTotal = CalcularValorTotalDoOrcamento(entity);
            //atualizar o orçamento
            return _mapper.Map<OrcamentoPorProjetoDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }

        public async Task<IEnumerable<OrcamentoPorProjetoDtoList>> FiltrarAsync(int? numero, Guid cliente)
        {
            return _mapper.Map<IEnumerable<OrcamentoPorProjetoDtoList>>(await _repository.Filtrar(numero, cliente));
        }
    }
}
