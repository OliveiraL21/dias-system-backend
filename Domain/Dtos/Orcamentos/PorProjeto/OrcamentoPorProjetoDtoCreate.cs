using Domain.Dtos.cliente;
using Domain.Dtos.Empresa;
using Domain.Dtos.Produto;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorProjeto
{
    public class OrcamentoPorProjetoDtoCreate
    {
        public Guid EmpresaId { get; set; }
        public Guid ClienteId { get; set; }
        public IEnumerable<ProdutoDto> Produtos { get; set; }
    }
}
