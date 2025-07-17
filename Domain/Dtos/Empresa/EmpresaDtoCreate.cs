using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Empresa
{
    public class EmpresaDtoCreate
    {
        [Required(ErrorMessage = "Razão Social é um campo obrigatória")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "Cpf é um campo obrigatório")]
        [MaxLength(11, ErrorMessage = "Cpf deve ter no máximo 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Telefone é um campo obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Celular é um campo obrigatório")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Celular inválido")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Logradouro é um campo obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número da residencia é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Bairro é um campo obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Cep é um campo obrigatório")]
        [DataType(DataType.PostalCode, ErrorMessage = "Cep inválido")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Cidade é um campo obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado é um campo obrigatório")]
        public string Estado { get; set; }

    }
}
