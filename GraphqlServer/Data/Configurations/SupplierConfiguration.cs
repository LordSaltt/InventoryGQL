using GraphqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlServer.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e=> e.Id);       

            builder.Property(e=> e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e=> e.Address).HasMaxLength(150).IsRequired();
            builder.Property(e=> e.Phone).HasMaxLength(20).IsRequired();
            builder.Property(e=> e.Contact).HasMaxLength(20).IsRequired();
            builder.Property(e=> e.Email).HasMaxLength(50).IsRequired();             
            builder.Property(e=> e.Comments).HasMaxLength(50).IsRequired();             
        }
    }
}