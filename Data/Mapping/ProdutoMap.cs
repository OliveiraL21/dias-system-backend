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
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.CreateAt).IsRequired();
            builder.Property(x => x.UpdateAt).IsRequired();

            builder.Property(x => x.Descricao);

            builder.Property(x => x.Quantidade).
                IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.HasOne(x => x.Orcamento)
                .WithMany(o => o.Produtos)
                .HasForeignKey(x => x.OrcamentoId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
