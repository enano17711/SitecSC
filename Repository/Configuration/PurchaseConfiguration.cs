using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasData(
            new Purchase
            {
                Id = new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"),
                PurchaseDate = new DateTime(2023, 1, 11),
                PurchaseTotal = 100
            });
    }
}