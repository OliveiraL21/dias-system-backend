using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Produto
{
    public class ProdutoDtoUpdate
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
