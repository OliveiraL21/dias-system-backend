using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using Domain.Services.Tarefas;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using Domain.Dtos.tarefas;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "admin, regular")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        [Route("filtrar")]
        public async Task<IActionResult> Filtrar([FromQuery] string? descricao, [FromQuery] string? dataInicio, [FromQuery] string? dataFim, [FromQuery] Guid? projetoId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tarefaService.FiltrarAsync(descricao, dataInicio, dataFim, projetoId);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
       
        public async Task<IActionResult> listarTarefas()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tarefaService.ListaAsync();

                if (result.Count() == 0 && result == null)
                {
                    return BadRequest();
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("duracao/{horarioInicio}/{horarioFim}")]
        public async Task<IActionResult> calcularDuracao(string horarioInicio, string horarioFim)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tarefaService.calcularDuracao(horarioInicio, horarioFim);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("horasTotais/{data}")]
        public async Task<IActionResult> calcularTotaisHoras(DateTime data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var total = await _tarefaService.calcularHorasTotaisAsync(data);

                var result = new
                {
                    HorasTotal = total
                };

                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("detalhes_tarefas/{id}")]
        public IActionResult details(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tarefaService.SelectAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult createTarefa([FromBody] TarefaDtoCreate tarefaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = this._tarefaService.InsertAsync(tarefaDto);

                if (result == null)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("update_tarefas/{id}")]
        public IActionResult updateTarefa(Guid id, [FromBody] TarefaDtoUpdate tarefaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tarefaService.UpdateAsync(id, tarefaDto);

                if (result == null)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> ExcluirTarefa(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tarefaService.DeleteAsync(id);

                if (!result)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("lista/projeto/{projeto}")]
        public async Task<IActionResult> ListaTarefasByProjeto(Guid projeto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tarefaService.ListaByProjetoAsync(projeto);

                if(result == null)
                {
                    return BadRequest(new ErrorHandle { Error = "Nenhuma tarefa encontrada" });
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
