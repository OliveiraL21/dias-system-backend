using AutoMapper;
using Domain.Dtos.Servico;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Repository;
using Domain.Services.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicos
{
    public class ServicoService : IServicoService
    {
        private readonly IRepository<ServicoEntity> _repository;
        private readonly IMapper _mapper;

        public ServicoService(IRepository<ServicoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServicoDtoCreateResult> CreateAsync(ServicoDtoCreate servico)
        {
            var model = _mapper.Map<ServicoModel>(servico);
            var entity = _mapper.Map<ServicoEntity>(model);
            return _mapper.Map<ServicoDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ServicoDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ServicoDto>>(await _repository.SelectAllAsync());
        }

        public async Task<ServicoDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ServicoDto>(await _repository.SelectAsync(id));
        }

        public async Task<ServicoDtoUpdateResult> UpdateAsync(Guid id, ServicoDtoUpdate servico)
        {
            var model = _mapper.Map<ServicoModel>(servico);
            var entity = _mapper.Map<ServicoEntity>(model);
            return _mapper.Map<ServicoDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
