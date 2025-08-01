using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Report
{
    public interface IReportService
    {
        Task<byte[]> OrcamentoPorProjeto(Guid id);
        Task<byte[]> ServicosPrestados(Guid projetoId);
        Task<byte[]> ServicosPrestadosPorPeriodo(Guid projetoId, DateTime dataInicio, DateTime dataFim);
    }
}
