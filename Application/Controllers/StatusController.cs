using Microsoft.AspNetCore.Mvc;
using Services.StatusService;
using System.Net;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Domain.Dtos.status;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController(StatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listaStatus")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> listaTodos()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _statusService.ListaAsync();

                if (result == null)
                {
                    return NotFound(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("createStatus")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> create([FromBody] StatusDtoCreate statusDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _statusService.InsertAsync(statusDTO);
                if(result == null)
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

        [HttpPut]
        [Route("updateStatus/{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> update(Guid id, [FromBody] StatusDtoUpdate status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _statusService.UpdateAsync(id, status);
                if(result == null)
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
        [Route("detalhes_status/{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> details(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _statusService.SelectAsync(id);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete_status/{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _statusService.DeleteAsync(id);
                
                if(result == false)
                {
                    return BadRequest();
                }

                return Ok(result);  
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
