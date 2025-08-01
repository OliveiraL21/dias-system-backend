using Domain.Dtos.ProdutoOrcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorProjeto
{
    public class OrcamentoPorProjetoDtoReport
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public double ValorTotal { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid ClienteId { get; set; }
        public string CreateAt { get; set; }
        public IEnumerable<ProdutoOrcamentoProjetoDto> Produtos { get; set; }
    }
}
