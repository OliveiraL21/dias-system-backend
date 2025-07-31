using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ProdutoOrcamentoProjetoEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotalVenda { get; set; }
        public OrcamentoPorProjetoEntity Orcamento { get; set; }
        public Guid OrcamentoId { get; set; }
        public ProdutoEntity Produto { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
