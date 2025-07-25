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
    public class ServicoMap : IEntityTypeConfiguration<ServicoEntity>
    {
        public void Configure(EntityTypeBuilder<ServicoEntity> builder)
        {
            builder.ToTable("Servico");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.CreateAt).IsRequired();
            builder.Property(x => x.UpdateAt);

            builder.Property(x => x.Descricao);
            builder.Property(x => x.QuantidadeHora);
          
            builder.HasOne(x => x.Orcamento)
                .WithMany(o => o.Servicos)
                .HasForeignKey(x => x.OrcamentoId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
