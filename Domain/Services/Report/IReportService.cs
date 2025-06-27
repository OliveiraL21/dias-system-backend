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
        Task<Stream> ServicosPrestados(Guid projetoId);
    }
}
