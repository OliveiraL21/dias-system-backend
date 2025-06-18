using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.tarefas
{
    public class TarefaProjetoDtoListagem
    {
        public int Total { get; set; }
        public IEnumerable<TarefaDto> Data { get; set; }
    }
}
