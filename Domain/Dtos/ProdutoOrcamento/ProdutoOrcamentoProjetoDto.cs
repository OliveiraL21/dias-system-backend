using Domain.Dtos.Orcamentos.PorProjeto;
using Domain.Dtos.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.ProdutoOrcamento
{
    public class ProdutoOrcamentoProjetoDto
    {
        public Guid Id { get; set; }
        public OrcamentoPorProjetoDto Orcamento { get; set; }
        public ProdutoDto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotalVenda { get; set; }
    }
}
