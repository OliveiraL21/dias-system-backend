using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ServicoModel : BaseModel
    {
		private string _descricao;

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		private string _quantidadeHora;

		public string QuantidadeHora
		{
			get { return _quantidadeHora; }
			set { _quantidadeHora = value; }
		}

		private Guid _orcamentoId;

		public Guid OrcamentoId
		{
			get { return _orcamentoId; }
			set { _orcamentoId = value; }
		}

	}
}
