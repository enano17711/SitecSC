using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.HasData(
            new Movement
            {
                Id = new Guid("d794045c-d231-4fa5-bb51-134fca92880d"),
                Price = 65.50m,
                Quantity = 200,
                ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                PurchaseId = new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"),
                SaleId = null
            },
            new Movement
            {
                Id = new Guid("3c4fef43-76fe-41ae-a019-3427be36237f"),
                Price = 34.50m,
                Quantity = 100,
                ProductId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                PurchaseId = new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"),
                SaleId = null
            });
    }
}