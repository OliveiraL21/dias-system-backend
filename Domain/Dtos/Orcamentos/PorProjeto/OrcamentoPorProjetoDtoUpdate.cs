using Domain.Dtos.cliente;
using Domain.Dtos.Empresa;
using Domain.Dtos.Produto;
using Domain.Dtos.ProdutoOrcamento;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorProjeto
{
    public class OrcamentoPorProjetoDtoUpdate
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public double ValorTotal { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<ProdutoOrcamentoProjetoDtoUpdate> Produtos { get; set; }
    }
}
