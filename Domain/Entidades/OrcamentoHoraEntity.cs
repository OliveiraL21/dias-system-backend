using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class OrcamentoHoraEntity : OrcamentoEntity
    {
        public int ValorHora { get; set; }
        public IEnumerable<ServicoEntity> Servicos { get; set; }
        public EmpresaEntity Empresa { get; set; }
        public Guid EmpresaId { get; set; }
        public ClienteEntity Cliente { get; set; }
        public Guid ClienteId { get; set; }
    }
}
