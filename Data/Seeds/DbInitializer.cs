using Data.Context;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeds
{
    public static class DbInitializer
    {
        public static void Seed(MyContext context)
        {
            if (!context.Status.Any())
            {
                context.AddRange(
                     new StatusEntity { Id = Guid.NewGuid(), Descricao = "Em andamento" },
                    new StatusEntity { Id = Guid.NewGuid(), Descricao = "Inativo" },
                    new StatusEntity { Id = Guid.NewGuid(), Descricao = "Em pausa" },
                    new StatusEntity { Id = Guid.NewGuid(), Descricao = "Excluído" },
                    new StatusEntity { Id = Guid.NewGuid(), Descricao = "Finalizado" },
                    new StatusEntity { Id = Guid.NewGuid(), Descricao = "Bloqueado" }
                );
            }


            if (!context.Empresas.Any())
            {
                context.AddRange(
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
                             CreateAt = DateTime.Now,
                             UpdateAt = null,
                         }
                );
            }

            context.SaveChanges();
        }
    }
}
