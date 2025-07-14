using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Servico
{
    public class ServicoDtoUpdate
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Quantidade é um campo obrigatório")]
        public string QuantidadeHora { get; set; }
    }
}
