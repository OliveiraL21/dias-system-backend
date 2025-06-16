using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.cliente
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Tipo { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
        public string Telefone { get; set; }
        public string? Celular { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string? Cep { get; set; }
        public string Cidade { get; set; }
    }
}
