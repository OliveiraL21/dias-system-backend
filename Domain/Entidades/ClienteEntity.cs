using System.Collections.Generic;

namespace Domain.Entidades
{
    public class ClienteEntity : BaseEntity
    {

        public string RazaoSocial { get; set; }

        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }

        public string Telefone { get; set; }

        public string? Celular { get; set; }

        public string Email { get; set; }

        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string? Cep { get; set; }
        public string Cidade { get; set; }

        public IEnumerable<ProjetoEntity>? Projetos { get; set; }
        public IEnumerable<OrcamentoHoraEntity>? OrcamentosHora { get; set; }
        public IEnumerable<OrcamentoPorProjetoEntity>? OrcamentosPorProjeto { get; set; }
    }
}