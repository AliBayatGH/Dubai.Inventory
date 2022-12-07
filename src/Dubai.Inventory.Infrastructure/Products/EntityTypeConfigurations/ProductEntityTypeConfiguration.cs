using Dubai.Inventory.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dubai.Inventory.Infrastructure.Products.EntityTypeConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Barcode).HasMaxLength(256).IsRequired();

        builder.HasData(
            new Product { Id = 1, Name = "Keyboard", Barcode = "1234", Description = "This is a good keybord", CategoryName = "Computer", IsWeighted = false },
            new Product { Id = 2, Name = "Mouse", Barcode = "5678", Description = "This is a good keybord", CategoryName = "Computer", IsWeighted = false },
            new Product { Id = 3, Name = "Monitor", Barcode = "9012", Description = "This is a good keybord", CategoryName = "Computer", IsWeighted = false },
            new Product { Id = 4, Name = "Case", Barcode = "3456", Description = "This is a good keybord", CategoryName = "Computer", IsWeighted = false }
        );
    }
}