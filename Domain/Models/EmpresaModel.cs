using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EmpresaModel :BaseModel
    {
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _razaoSocial;

		public string RazaoSocial
		{
			get { return _razaoSocial; }
			set { _razaoSocial = value; }
		}


		private string _telefone;

		public string Telefone
		{
			get { return _telefone; }
			set { _telefone = value; }
		}

		private string _celular;

		public string Celular
		{
			get { return _celular; }
			set { _celular = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private string _logradouro;

		public string Logradouro
		{
			get { return _logradouro; }
			set { _logradouro = value; }
		}

		private string _numero;

		public string Numero
		{
			get { return _numero; }
			set { _numero = value; }
		}

		private string _bairro;

		public string Bairro
		{
			get { return _bairro; }
			set { _bairro = value; }
		}

		private string _cep;

		public string Cep
		{
			get { return _cep; }
			set { _cep = value; }
		}

		private string _cidade;

		public string Cidade
		{
			get { return _cidade; }
			set { _cidade = value; }
		}

		private string _estado;

		public string Estado
		{
			get { return _estado; }
			set { _estado = value; }
		}

		private IEnumerable<OrcamentoPorProjetoEntity>? _orcamentosPorProjeto;

		public IEnumerable<OrcamentoPorProjetoEntity>? OrcamentosPorProjeto
        {
			get { return _orcamentosPorProjeto; }
			set { _orcamentosPorProjeto = value; }
		}


        private IEnumerable<OrcamentoHoraEntity>? _orcamentosHora;

        public IEnumerable<OrcamentoHoraEntity>? OrcamentosHora
        {
            get { return _orcamentosHora; }
            set { _orcamentosHora = value; }
        }

    }
}
