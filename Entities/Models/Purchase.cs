using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public class Purchase
{
    [Column("PurchaseId")]
    public Guid Id { get; set; }

    
    [Required(ErrorMessage = "PurchaseDate is required")]
    [Column(TypeName = "date")]
    public DateTime? PurchaseDate { get; set; }

    
    [Required(ErrorMessage = "PurchaseTotal is required")]
    [Precision(11,2)]
    public decimal PurchaseTotal { get; set; }

    
    public ICollection<Movement>? Movements { get; set; }
}