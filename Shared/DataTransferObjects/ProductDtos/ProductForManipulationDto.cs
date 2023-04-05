using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.ProductDtos;

public abstract record ProductForManipulationDto
{
    [Required(ErrorMessage = "Product Name is required")]
    [MaxLength(25, ErrorMessage = "Name most be less than 25 characters")]
    public string? Name { get; init; }
    
    
    [Required(ErrorMessage = "Product Description is required")]
    [MaxLength(100, ErrorMessage = "Description most be less than 100 characters")]
    public string? Description { get; init; }
}