using Domain.Dtos.cliente;
using Domain.Dtos.Empresa;
using Domain.Dtos.Servico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorHora
{
    public class OrcamentoHoraDtoCreate
    {
        [Required(ErrorMessage = "O campo Valor da hora é obrigatório.")]
        public int ValorHora { get; set; }
        public string? TempoDeEntrega { get; set; }
        [Required(ErrorMessage = "O campo Serviços é obrigatório.")]
        public IEnumerable<ServicoDto> Servicos { get; set; }
        [Required(ErrorMessage = "O campo Empresa é obrigatório.")]
        public Guid EmpresaId { get; set; }
        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public Guid ClienteId { get; set; }
    }
}
