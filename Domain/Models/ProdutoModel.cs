using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProdutoModel : BaseModel
    {
		private string _descricao;

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}


		private IEnumerable<ProdutoOrcamentoProjetoEntity> _produtosOrcamentos;

		public IEnumerable<ProdutoOrcamentoProjetoEntity> ProdutosOrcamentos
		{
			get { return _produtosOrcamentos; }
			set { _produtosOrcamentos = value; }
		}

		private double _valor;

		public double Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}




	}
}
