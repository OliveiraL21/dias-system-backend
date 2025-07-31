using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.ProdutoOrcamento
{
    public class ProdutoOrcamentoProjetoDtoUpdate
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotalVenda { get; set; }
        public Guid OrcamentoId { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
