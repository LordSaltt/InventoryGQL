using Microsoft.EntityFrameworkCore;
using GraphqlServer.Models;

namespace GraphqlServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Brand> Brands { get; set; } = default!; 
        public DbSet<Category> Categories { get; set; } = default!; 
        public DbSet<Supplier> Suppliers { get; set; } = default!; 
        public DbSet<SupplierProduct> SupplierProducts { get; set; } = default!; 
        public DbSet<User> Users { get; set; } = default!; 
    }
}