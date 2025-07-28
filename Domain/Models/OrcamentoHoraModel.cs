using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrcamentoHoraModel : BaseModel
    {
		private int _valorHora;

		public int ValorHora
		{
			get { return _valorHora; }
			set { _valorHora = value; }
		}

		private int _numero;

		public int Numero
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


		private IEnumerable<ServicoEntity> _servicos;

		public IEnumerable<ServicoEntity> Servicos
		{
			get { return _servicos; }
			set { _servicos = value; }
		}

		private Guid _empresaId;

		public Guid EmpresaId
		{
			get { return _empresaId; }
			set { _empresaId = value; }
		}

		private Guid _clienteId;

		public Guid ClienteId
		{
			get { return _clienteId; }
			set { _clienteId = value; }
		}



	}
}
