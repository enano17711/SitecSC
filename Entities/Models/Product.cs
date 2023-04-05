using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Product
{
    [Column("ProductId")]
    public Guid Id { get; set; }
    
    
    [Required(ErrorMessage = "Product Name is required")]
    [MaxLength(25, ErrorMessage = "Name most be less than 25 characters")]
    public string? Name { get; set; }
    
    
    [MaxLength(100, ErrorMessage = "Description most be less than 100 characters")]
    public string? Description { get; set; }
    

    public ICollection<Movement>? Movements { get; set; }
}