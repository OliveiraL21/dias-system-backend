using Domain.Dtos.cliente;
using Domain.Dtos.status;
using Domain.Entidades;
using System;

namespace Domain.Dtos.projeto
{
    public class ProjetoDtoListagem
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public StatusDto status { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public ClienteDto Cliente { get; set; }
    }
}
