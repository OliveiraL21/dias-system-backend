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
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public OrcamentoPorProjetoEntity Orcamento { get; set; }
        public Guid OrcamentoId { get; set; }
    }
}
