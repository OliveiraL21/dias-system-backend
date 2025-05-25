using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.status
{
    public class StatusDtoCreate
    {
        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Descricao { get; set; }
    }
}
