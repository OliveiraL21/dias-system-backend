using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeds
{
    public static class StatusSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusEntity>().HasData(
                new StatusEntity { Id = Guid.NewGuid(), Descricao = "Em andamento" },
                new StatusEntity { Id = Guid.NewGuid(), Descricao = "Inativo" },
                new StatusEntity { Id = Guid.NewGuid(), Descricao = "Em pausa" },
                new StatusEntity { Id = Guid.NewGuid(), Descricao = "Excluído" },
                new StatusEntity { Id = Guid.NewGuid(), Descricao = "Finalizado" },
                new StatusEntity { Id = Guid.NewGuid(), Descricao = "Bloqueado" }
            );
        }
    }
}
