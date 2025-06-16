using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.cliente
{
    public class ClienteDtoCreate
    {
        [Required(ErrorMessage = "Razão social é um campo obrigatório")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "Cnpj é um campo obrigatório")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Telefone é um campo obrigatório")]
        public string Telefone { get; set; }
        public string? Celular { get; set; }
        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        public string Email { get; set; }
    }
}
