﻿namespace Entities.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id) : base($"Product with id {id} was not found.")
    {
    }
}