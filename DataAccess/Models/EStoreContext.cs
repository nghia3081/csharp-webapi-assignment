using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public class EStoreContext : DbContext
    {
        public EStoreContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(orderDetail => new { orderDetail.OrderId, orderDetail.ProductId });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
        internal DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        internal DbSet<Category> Categories { get; set; } = null!;
        internal DbSet<Order> Orders { get; set; } = null!;
        internal DbSet<Member> Members { get; set; } = null!;
        internal DbSet<Product> Products { get; set; } = null!;
    }
}
