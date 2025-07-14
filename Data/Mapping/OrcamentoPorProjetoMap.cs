using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class OrcamentoPorProjetoMap : IEntityTypeConfiguration<OrcamentoPorProjetoEntity>
    {
        public void Configure(EntityTypeBuilder<OrcamentoPorProjetoEntity> builder)
        {
            builder.ToTable("OrcamentoPorProjeto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Numero).IsRequired();
            builder.HasIndex(x => x.Numero).IsUnique();

            builder.Property(x => x.CreateAt).IsRequired();
            builder.Property(x => x.UpdateAt).IsRequired();
            builder.Property(x => x.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
           
            builder.HasOne(x => x.Empresa).WithMany(e => e.OrcamentosPorProjeto)
                .HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(c => c.OrcamentosPorProjeto)
                .HasForeignKey(c => c.ClienteId);

            builder.HasMany(x => x.Produtos).WithOne(p => p.Orcamento);
                

        }
    }
}
