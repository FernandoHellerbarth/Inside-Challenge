using InsideChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsideChallenge.Infrastructure.Data
{
    public class InsideChallengeContext : DbContext
    {

        public InsideChallengeContext(DbContextOptions<InsideChallengeContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                   .HasMany(x => x.Items)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
