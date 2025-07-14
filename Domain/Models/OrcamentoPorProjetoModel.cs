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

		private IEnumerable<ProdutoEntity> _produtos;

		public IEnumerable<ProdutoEntity> Produtos
		{
			get { return _produtos; }
			set { _produtos = value; }
		}

	}
}
