using Data.Mapping;
using Data.Seeds;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        public DbSet<ProjetoEntity> Projetos { get; set; }

        public DbSet<ClienteEntity> Clientes { get; set; }

        public DbSet<TarefaEntity> Tarefas { get; set; }

        public DbSet<StatusEntity> Status { get; set; }

        public DbSet<EmpresaEntity> Empresas { get; set; }

        public MyContext(DbContextOptions<MyContext>options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>(new UsuarioMap().Configure);
            modelBuilder.Entity<ProjetoEntity>(new ProjetoMap().Configure);
            modelBuilder.Entity<ClienteEntity>(new ClienteMap().Configure);
            modelBuilder.Entity<TarefaEntity>(new TarefaMap().Configure); 
            modelBuilder.Entity<StatusEntity>(new StatusMap().Configure);
            modelBuilder.Entity<EmpresaEntity>(new EmpresaMap().Configure);

            StatusSeed.Seed(modelBuilder);
            EmpresaSeed.Seed(modelBuilder);


        }
    }
}
