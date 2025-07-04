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
        Task<byte[]> ServicosPrestados(Guid projetoId);
    }
}
