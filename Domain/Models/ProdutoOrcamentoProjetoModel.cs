using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProdutoOrcamentoProjetoModel : BaseModel
    {

		private string _descricao;

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		private int _quantidade;

		public int Quantidade
		{
			get { return _quantidade; }
			set { _quantidade = value; }
		}

		private double _valorTotalVenda;

		public double ValorTotalVenda
		{
			get { return _valorTotalVenda; }
			set { _valorTotalVenda = value; }
		}

		private Guid _orcamentoId;

		public Guid OrcamentoId
		{
			get { return _orcamentoId; }
			set { _orcamentoId = value; }
		}


		private Guid _produtoId;

		public Guid ProdutoId
		{
			get { return _produtoId; }
			set { _produtoId = value; }
		}


	}
}
