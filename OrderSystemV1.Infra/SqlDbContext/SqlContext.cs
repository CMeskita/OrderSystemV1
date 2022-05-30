using Microsoft.EntityFrameworkCore;
using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Infra.SqlMap;

namespace OrderSystemV1.Infra.SqlDbContext
{

    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new OrderMap());
            //modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.HasSequence<int>("ReferenceClient").StartsAt(1000).IncrementsBy(1);
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.HasSequence<int>("RefenceProduct").StartsAt(1000).IncrementsBy(1);
            base.OnModelCreating(modelBuilder);
        }

    }
}
