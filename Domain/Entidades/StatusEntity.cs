using System.Collections.Generic;

namespace Domain.Entidades
{
    public class StatusEntity : BaseEntity
    {

        public string Descricao { get; set; }

        public List<ProjetoEntity> Projetos { get; set; }

        public List<TarefaEntity> Tarefas { get; set; }
        public List<OrcamentoPorProjetoEntity> OrcamentosPorProjeto { get; set; }
        public List<OrcamentoHoraEntity> OrcamentosHora { get; set; }
        public List<EmpresaEntity> Empresas { get; set; }
    }
}