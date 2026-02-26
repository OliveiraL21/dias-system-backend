using Domain.Dtos.cliente;
using Domain.Dtos.status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.projeto
{
    public class ProjetoDtoCreate
    {
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo data início é obrigatório.")]
        public string DataInicio { get; set; }
        [Required(ErrorMessage = "O valor da hora do projeto é obrigatório")]
        public double ValorHora { get; set; }
        [Required(ErrorMessage = "O campo status é obrigatório.")]
        public StatusDto Status { get; set; }
        [Required(ErrorMessage = "O campo cliente é obrigatório.")]
        public ClienteDto Cliente { get; set; }
    }
}
