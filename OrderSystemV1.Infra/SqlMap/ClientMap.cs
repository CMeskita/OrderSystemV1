using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderSystemV1.Domain.Entity;

namespace OrderSystemV1.Infra.SqlMap
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("TB_CLIENT");

            builder.HasKey(client => client.Id);

            builder.Property(client => client.Id)
                .HasColumnName("ID");

            builder.Property(client => client.ReferenceClient)
             .HasColumnName("CLIENT_REF")
             .HasDefaultValueSql("NEXT VALUE FOR ReferenceClient")
             .IsRequired();

            builder.Property(client => client.Name)
                .HasColumnName("CLIENT_NAME")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(client => client.Email)
               .HasColumnName("CLIENT_EMAIL")
               .HasMaxLength(100)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(client => client.BirthDate)
               .HasColumnName("CLIENT_BIRTHDATE")
               .IsRequired();
            builder.Ignore(x => x.Errors);
        }
    }
}
