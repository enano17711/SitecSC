using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects.PurchaseDtos;

public abstract record PurchaseForManipulationDto
{
    [Required(ErrorMessage = "PurchaseDate is required")]
    public DateTime PurchaseDate { get; init; } = DateTime.Today;
    
    [JsonIgnore]
    [Range(0f, float.MaxValue, ErrorMessage = "PurchaseTotal must be greater than 0")]
    public decimal PurchaseTotal { get; init; }
}