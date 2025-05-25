using AutoMapper;
using Data.Context;
using Domain.Dtos.status;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Repository;
using Domain.Services.Status;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository repository, IMapper mapper)
        {
           _repository= repository;
            _mapper= mapper;
        }

        public async Task<StatusDtoCreateResult> InsertAsync(StatusDtoCreate status)
        {
            var model = _mapper.Map<StatusModel>(status);
            var entity = _mapper.Map<StatusEntity>(model);
            return _mapper.Map<StatusDtoCreateResult>( await _repository.InsertAsync(entity));
           
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);        }

        public async Task<StatusDto> SelectAsync(Guid id)
        {
            return _mapper.Map<StatusDto>(await _repository.SelectAsync(id));
        }

        public async Task<IEnumerable<StatusDtoListagem>> ListaAsync()
        {
            return _mapper.Map<IEnumerable<StatusDtoListagem>>(await _repository.GetAllAsync());
        }

        public async Task<StatusDtoUpdateResult> UpdateAsync(Guid id, StatusDtoUpdate status)
        {
            var model = _mapper.Map<StatusModel>(status);
            var entity = _mapper.Map<StatusEntity>(model);
           return _mapper.Map<StatusDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }
    }
}
