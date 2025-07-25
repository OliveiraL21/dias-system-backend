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
    public class OrcamentoHoraMap : IEntityTypeConfiguration<OrcamentoHoraEntity>
    {
        public void Configure(EntityTypeBuilder<OrcamentoHoraEntity> builder)
        {
            builder.ToTable("OrcamentoHora");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.CreateAt).IsRequired();
            builder.Property(x => x.UpdateAt);

            builder.Property(x => x.Numero).IsRequired();
            builder.HasIndex(x => x.Numero).IsUnique();

            builder.Property(x => x.ValorHora)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(x => x.Empresa).WithMany(o => o.OrcamentosHora).HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(c => c.OrcamentosHora)
                .HasForeignKey(x => x.ClienteId);

            builder.HasMany(x => x.Servicos).WithOne(s => s.Orcamento);


        }
    }
}
