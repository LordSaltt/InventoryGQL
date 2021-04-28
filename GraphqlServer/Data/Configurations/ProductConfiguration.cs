using GraphqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlServer.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e=> e.Id);
            builder.HasOne(e => e.Brand)
                   .WithMany(p => p.Products)
                   .HasForeignKey(b=> b.BrandId);

            builder.HasOne(e => e.Category)
                   .WithMany(p => p.Products)
                   .HasForeignKey(b=> b.CategoryId);

            builder.Property(e=> e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e=> e.Description).HasMaxLength(150).IsRequired();
            builder.Property(e=> e.UOM).HasMaxLength(20).IsRequired();
            builder.Property(e=> e.Status).HasMaxLength(20).IsRequired();        
        }
    }
}