using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ProdutoEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public IEnumerable<ProdutoOrcamentoProjetoEntity> ProdutosOrcamentos { get; set; }
    }
}
