using Domain.Dtos.ProdutoOrcamento;
using Domain.Services.ProdutoOrcamento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoOrcamentoPorProjetoController : ControllerBase
    {
        private readonly IProdutoOrcamentoPorProjetoService _service;
        public ProdutoOrcamentoPorProjetoController(IProdutoOrcamentoPorProjetoService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult>Delete(Guid id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.Delete(id);
                return Ok(result);
            } catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult>Details(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.Get(id);

                return Ok(result);

            } catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.GetAll();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ProdutoOrcamentoProjetoDtoCreate produto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.Create(produto);

                return Ok(result);

            } catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult>Update(Guid id, [FromBody] ProdutoOrcamentoProjetoDtoUpdate produto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.Update(id,produto);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
