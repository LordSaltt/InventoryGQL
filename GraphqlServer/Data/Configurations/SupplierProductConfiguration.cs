using GraphqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlServer.Data.Configurations
{
    public class SupplierProductConfiguration : IEntityTypeConfiguration<SupplierProduct>
    {
        public void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Supplier)
                   .WithMany(s => s.SupplierProducts)
                   .HasForeignKey(f => f.SupplierId);

            builder.HasOne(e => e.Product)
                   .WithMany(s => s.SuplierProducts)
                   .HasForeignKey(f => f.ProductId);


        }
    }
}