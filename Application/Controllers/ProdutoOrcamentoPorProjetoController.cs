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
    }
}
