using commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace commerce.Models
{
    public class CartContext : DbContext
    {
        public CartContext() { }
        public CartContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> User { get; set; }
        public DbSet<ShoppingCart> ShoppingCartTable { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> ProductTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.User)
                .WithOne(u => u.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.ShoppingCart)
                .WithMany(sc => sc.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}