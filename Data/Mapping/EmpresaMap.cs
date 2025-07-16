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
    public class EmpresaMap : IEntityTypeConfiguration<EmpresaEntity>
    {
        public void Configure(EntityTypeBuilder<EmpresaEntity> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.RazaoSocial).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Cpf).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Telefone).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Celular).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Logradouro).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Numero).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Cep).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Estado).IsRequired().HasMaxLength(2);

            builder.HasMany(e => e.OrcamentosHora)
                   .WithOne(o => o.Empresa);
            builder.HasMany(e => e.OrcamentosPorProjeto)
                     .WithOne(o => o.Empresa);
            builder.HasOne(o => o.Status).WithMany(s => s.Empresas).HasForeignKey(o => o.StatusId);

        }
    }
}
