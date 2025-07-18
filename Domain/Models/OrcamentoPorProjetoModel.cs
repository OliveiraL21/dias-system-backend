using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrcamentoPorProjetoModel : BaseModel
    {
		private Guid empresaId;

		public Guid EmpresaId
		{
			get { return empresaId; }
			set { empresaId = value; }
		}

		private Guid _clienteId;

		public Guid ClienteId
		{
			get { return _clienteId; }
			set { _clienteId = value; }
		}

		private IEnumerable<ProdutoOrcamentoProjetoEntity> _produtos;

		public IEnumerable<ProdutoOrcamentoProjetoEntity> Produtos
		{
			get { return _produtos; }
			set { _produtos = value; }
		}

		private string _numero;

		public string Numero
		{
			get { return _numero; }
			set { _numero = value; }
		}

		private double _valorTotal;

		public double ValorTotal
		{
			get { return _valorTotal; }
			set { _valorTotal = value; }
		}


	}
}
