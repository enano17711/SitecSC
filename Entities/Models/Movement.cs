using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public class Movement
{
    [Column("MovementId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    public int? Quantity { get; set; }
    
    
    [Required(ErrorMessage = "Price is required")]
    [Precision(11,2)]
    public decimal? Price { get; set; }

    
    [ForeignKey(nameof(Product))]
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }

    
    [ForeignKey(nameof(Purchase))]
    public Guid? PurchaseId { get;set; }
    public Purchase? Purchase { get; set; }


    [ForeignKey(nameof(Sale))]
    public Guid? SaleId { get; set;}
    public Sale? Sale { get; set; }
}