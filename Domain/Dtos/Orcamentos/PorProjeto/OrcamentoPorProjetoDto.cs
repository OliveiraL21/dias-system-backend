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
    public class OrcamentoPorProjetoDto
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public double ValorTotal { get; set; }
        public EmpresaDto Empresa { get; set; }
        public ClienteDto Cliente { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<ProdutoDto> Produtos { get; set; }
    }
}
