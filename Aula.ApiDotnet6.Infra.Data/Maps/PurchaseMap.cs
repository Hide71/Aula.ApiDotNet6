using Aula.ApiDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aula.ApiDotnet6.Infra.Data.Maps
{
    public class PurchaseMap: IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IdCompra").UseIdentityColumn();
            builder.Property(c => c.PersonId).HasColumnName("IdPessoa");
            builder.Property(c => c.ProductId).HasColumnName("IdProduto");
            builder.Property(c => c.Date).HasColumnName("DataCompra");

            builder.HasOne(c => c.Person).WithMany(c => c.Purchase);
            builder.HasOne(c => c.Product).WithMany(c => c.Purchase);
        }
    }
}
