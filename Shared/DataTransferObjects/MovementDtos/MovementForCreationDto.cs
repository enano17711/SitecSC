using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.MovementDtos;

public record MovementForCreationDto : MovementForManipulationDto
{
    [Required(ErrorMessage = "Product is required")]
    public string? ProductId { get; init; }
}