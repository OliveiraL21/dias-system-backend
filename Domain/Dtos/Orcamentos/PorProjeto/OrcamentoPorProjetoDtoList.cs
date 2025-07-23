using Domain.Dtos.cliente;
using Domain.Dtos.Empresa;
using Domain.Dtos.ProdutoOrcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Orcamentos.PorProjeto
{
    public class OrcamentoPorProjetoDtoList
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public double ValorTotal { get; set; }
        public EmpresaDto Empresa { get; set; }
        public ClienteDto Cliente { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public IEnumerable<ProdutoOrcamentoProjetoDto> Produtos { get; set; }
    }
}
