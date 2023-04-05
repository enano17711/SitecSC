using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public class Sale
{
    [Column("SaleId")]
    public Guid Id { get; set; }

    
    [Required(ErrorMessage = "SaleDate is required")]
    [Column(TypeName = "date")]
    public DateTime? SaleDate { get; set; }

    
    [Required(ErrorMessage = "SaleTotal is required")]
    [Precision(11,2)]
    public decimal SaleTotal { get; set; }

    
    public ICollection<Movement>? Movements { get; set; }
}