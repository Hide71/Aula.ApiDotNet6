using Aula.ApiDotnet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ApiDotnet6.Infra.Data.Maps
{
    public class PersonMap:IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("IdPessoa").UseIdentityColumn();
            builder.Property(c => c.Document).HasColumnName("Documento");
            builder.Property(c => c.Name).HasColumnName("Nome");
            builder.Property(c => c.Phone).HasColumnName("Celular");

            builder.HasMany(c => c.Purchase)
                .WithOne(p => p.Person)
                .HasForeignKey(c => c.PersonId);
        }
    }
}
