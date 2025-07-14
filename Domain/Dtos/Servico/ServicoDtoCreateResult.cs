using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Servico
{
    public class ServicoDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string QuantidadeHora { get; set; }
    }
}
