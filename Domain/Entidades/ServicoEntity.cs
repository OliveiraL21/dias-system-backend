using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ServicoEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public string QuantidadeHora { get; set; }
        public OrcamentoHoraEntity Orcamento { get; set; }
        public Guid OrcamentoId { get; set; }
    }
}
