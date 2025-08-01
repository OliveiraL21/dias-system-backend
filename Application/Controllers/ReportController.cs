using Domain.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("orcamentoPorProjeto/{id}")]
        public async Task<IActionResult> ExportOrcamentoPorProjeto(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.OrcamentoPorProjeto(id);

                return File(result, "application/pdf", "orcamento-projeto.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("servicosPrestados/{id}")]
        public async Task<IActionResult> ExportServicosPrestados(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var report = await _service.ServicosPrestados(id);

                return File(report, "application/pdf", "relatorios-servicos-prestados.pdf");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("ServicosPrestadosPeriodo/{id}/{dataInicio}/{dataFim}")]
        public async Task<IActionResult> ExportServicosPrestadosPorPeriodo(Guid id, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var report = await _service.ServicosPrestadosPorPeriodo(id, dataInicio, dataFim);
                return File(report, "application/pdf", "relatorios-servicos-prestados-por-periodo.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
