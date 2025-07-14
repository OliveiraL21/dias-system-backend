using Domain.Dtos.cliente;
using Domain.Dtos.Empresa;
using Domain.Dtos.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorHora
{
    public class OrcamentoHoraDtoCreateResult
    {
        public Guid Id { get; set; }
        public int ValorHora { get; set; }
        public IEnumerable<ServicoDto> Servicos { get; set; }
        public EmpresaDto Empresa { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
