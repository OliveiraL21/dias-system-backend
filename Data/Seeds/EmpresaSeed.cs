using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeds
{
    public static class EmpresaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpresaEntity>().HasData(
                new EmpresaEntity
                {
                    Id = Guid.NewGuid(),
                    RazaoSocial = "Lucas José Dias de Oliveira",
                    Cpf = "476.593.238-90",
                    Telefone = "(19) 3861-7897",
                    Celular = "(19) 99669-3155",
                    Email = "ljoliveira99@outlook.com",
                    Logradouro = "Av São Carlos",
                    Numero = "791",
                    Bairro = "Vila São Carlos",
                    Cep = "13847-111",
                    Cidade = "Mogi Guaçu",
                    Estado = "SP",
                }
            );
        }
    }
}
