using Microsoft.EntityFrameworkCore;
using InventoryTask.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace InventoryTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductWarehouse>()
            .HasKey(pw => new
            {
                pw.ProductID,
                pw.WarehouseID
            });
            modelBuilder.Entity<IdentityRole>().HasData(
              new IdentityRole
              {
                  Id = Guid.NewGuid().ToString(),
                  Name = "Admin",
                  NormalizedName = "ADMIN"
              },
           new IdentityRole
           {
               Id = Guid.NewGuid().ToString(),
               Name = "User",
               NormalizedName = "USER"
           }
           );
        }
    }
}
