using Domain.Dtos.cliente;
using Domain.Dtos.status;
using Domain.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.projeto
{
    public class ProjetoDtoUpdate
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo data início é obrigatório.")]
        public string DataInicio { get; set; }
        public string? DataFim { get; set; }
        [Required(ErrorMessage = "O valor da hora do projeto é obrigatório")]
        public double ValorHora { get; set; }
        [Required(ErrorMessage = "O campo status é obrigatório.")]
        public StatusDto Status { get; set; }
        [Required(ErrorMessage = "O campo cliente é obrigatório.")]
        public ClienteDto Cliente { get; set; }
    }
}
