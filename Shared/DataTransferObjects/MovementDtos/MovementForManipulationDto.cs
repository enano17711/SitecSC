using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.MovementDtos;

public abstract record MovementForManipulationDto
{
    private decimal _price = 0m;

    
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; init; }

    
    [Range(0f, float.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price
    {
        get => _price;
        set => _price = Math.Round(value, 2, MidpointRounding.ToEven);
    }
}