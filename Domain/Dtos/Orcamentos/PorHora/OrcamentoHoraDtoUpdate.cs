using Domain.Dtos.Servico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorHora
{
    public class OrcamentoHoraDtoUpdate
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo número do orçamento é obrigatório.")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo valor total é obrigatório.")]
        public double ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo Valor da hora é obrigatório.")]
        public int ValorHora { get; set; }
        [Required(ErrorMessage = "O campo Serviços é obrigatório.")]
        public IEnumerable<ServicoDtoUpdate> Servicos { get; set; }
        [Required(ErrorMessage = "O campo Empresa é obrigatório.")]
        public Guid EmpresaId { get; set; }
        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public Guid ClienteId { get; set; }
        [Required(ErrorMessage = "O campo data do orçamento é obrigatório.")]
        public DateTimeOffset CreateAt { get; set; }
    }
}
