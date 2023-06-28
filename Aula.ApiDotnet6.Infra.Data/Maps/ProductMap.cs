using Aula.ApiDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula.ApiDotnet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Idproduto").UseIdentityColumn();
            builder.Property(x => x.CodErp).HasColumnName("Coderp").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Nome");
            builder.Property(x => x.Price).HasColumnName("Preco");

            builder.HasMany(x => x.Purchases).WithOne(c => c.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
