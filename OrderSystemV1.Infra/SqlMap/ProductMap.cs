using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderSystemV1.Domain.Entity;

namespace OrderSystemV1.Infra.SqlMap
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUCT");

            builder.HasKey(product => product.Id);

            builder.Property(user => user.Id)
                .HasColumnName("ID");

            builder.Property(product => product.RefenceProduct)
           .HasColumnName("PRODUCT_REFERENCE")
           .HasDefaultValueSql("NEXT VALUE FOR RefenceProduct")
           .IsRequired();

            builder.Property(product => product.Name)
              .HasColumnName("PRODUCT_NAME")
              .HasMaxLength(100)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(product => product.Price)
             .HasColumnName("PRODUCT_PRICE")
             .HasColumnType("decimal")
             .IsRequired();


            builder.Ignore(x => x.Errors);
        }
    }
}
