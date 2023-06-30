using Aula.ApiDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula.ApiDotnet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("idcompra").UseIdentityColumn();
            builder.Property(c => c.PersonId).HasColumnName("idpessoa");
            builder.Property(c => c.ProductId).HasColumnName("idproduto");
            builder.Property(c => c.Date).HasColumnName("datacompra");

            builder.HasOne(c => c.Person).WithMany(c => c.Purchases);
            builder.HasOne(c => c.Product).WithMany(c => c.Purchases);
        }
    }
}
