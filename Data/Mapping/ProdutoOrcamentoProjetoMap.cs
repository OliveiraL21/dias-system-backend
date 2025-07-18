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
    public class ProdutoOrcamentoProjetoMap : IEntityTypeConfiguration<ProdutoOrcamentoProjetoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoOrcamentoProjetoEntity> builder)
        {
            builder.ToTable("produtoOrcamentoProjeto");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.ValorTotalVenda);

            builder.HasOne(x => x.Orcamento).WithMany(o => o.Produtos).HasForeignKey(x => x.OrcamentoId);
            builder.HasOne(x => x.Produto).WithMany(p => p.ProdutosOrcamentos).HasForeignKey(x => x.ProdutoId);
        }
    }
}
