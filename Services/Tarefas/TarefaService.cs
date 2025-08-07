using AutoMapper;
using Data.Context;
using Domain.Dtos.dashboard;
using Domain.Dtos.tarefas;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Repository;
using Domain.Services.Tarefas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tarefas
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly IMapper _mapper;
        public TarefaService(ITarefaRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<string> calcularHorasTotaisAsync(DateTime data)
        {
           return await _repository.calcularHorasTotaisAsync(data);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _repository.DeleteAsync(id);
            }
            return false;
        }

        
        public async Task<IEnumerable<TarefaDto>> FiltrarAsync(string? descricao, string? dataInicio, string? dataFim, Guid? projetoId)
        {
            return _mapper.Map<IEnumerable<TarefaDto>>((await _repository.FiltrarAsync(descricao, dataInicio, dataFim, projetoId)).OrderBy(x => x.Descricao));
        }

        public async Task<TarefaDtoCreateResult> InsertAsync(TarefaDtoCreate tarefa)
        {
            if (tarefa != null)
            {
                var model = _mapper.Map<TarefaModel>(tarefa);
                var entity = _mapper.Map<TarefaEntity>(model);
                return _mapper.Map<TarefaDtoCreateResult>(await _repository.InsertAsync(entity));
            }
            return null;
        }

        public async Task<IEnumerable<TarefaDto>> ListaAsync()
        {
            return _mapper.Map<IEnumerable<TarefaDto>>((await _repository.GetAllAsync()).OrderBy(x => x.Descricao));
        }

        public async Task<TarefaDto> SelectAsync(Guid id)
        {
            return _mapper.Map<TarefaDto>(await _repository.SelectAsync(id));
        }

        public async Task<TarefaDtoUpdateResult> UpdateAsync(Guid id, TarefaDtoUpdate tarefa)
        {
            tarefa.Id = tarefa.Id == Guid.Empty ? id : tarefa.Id;
            var model = _mapper.Map<TarefaModel>(tarefa);
            var entity = _mapper.Map<TarefaEntity>(model);
            return _mapper.Map<TarefaDtoUpdateResult>(await _repository.UpdateAsync(id, entity));
        }

      

        public async Task<DashboardDtoResult> ListaByProjetoDashboardAsync(Guid projeto)
        {
            return await _repository.ListByProjetoDashboardAsync(projeto);
        }

        public async Task<object> calcularDuracao(string horarioInicio, string horarioFim)
        {
            var periodoInicio = horarioInicio.Split(":");
            var periodoFinal = horarioFim.Split(":");

            var periodoInicial = new TimeSpan((int)long.Parse(periodoInicio[0]), (int)long.Parse(periodoInicio[1]), 0);
            var periodoFim = new TimeSpan((int)long.Parse(periodoFinal[0]), (int)long.Parse(periodoFinal[1]), 0);

            var duracao = periodoFim.Add(-periodoInicial);
            var result = new
            {
                Duracao = duracao.ToString(),
            };
            return result;
        }

        public async Task<TarefaProjetoDtoListagem> GetAllByProject(int pageNumber, int pageSize, Guid projeto)
        {
            try
            {
                var tarefas = _mapper.Map<IEnumerable<TarefaDto>>(await _repository.GetAllByProjectAsync(projeto))
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize);
                var result = new TarefaProjetoDtoListagem()
                {
                    Total = await _repository.GetTotalTarefasByProjectAsync(),
                    Data = tarefas.OrderBy(tarefa => tarefa.Data),
                };
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
