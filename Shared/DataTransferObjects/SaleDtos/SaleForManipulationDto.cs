using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects.SaleDtos;

public abstract record SaleForManipulationDto
{
    [Required(ErrorMessage = "SaleDate is required")]
    public DateTime SaleDate { get; init; } = DateTime.Today;
    
    [JsonIgnore]
    [Range(0f, float.MaxValue, ErrorMessage = "SaleTotal must be greater than 0")]
    public decimal SaleTotal { get; init; }
}