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
        public string Tipo { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "Telefone é um campo obrigatório")]
        public string Telefone { get; set; }
        public string? Celular { get; set; }
        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string? Cep { get; set; }
        public string Cidade { get; set; }


    }
}
