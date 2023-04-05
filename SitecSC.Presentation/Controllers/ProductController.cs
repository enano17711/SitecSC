using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.ProductDtos;
using Shared.RequestFeatures;
using SitecSC.Presentation.ActionFilters;
using Swashbuckle.AspNetCore.Annotations;

namespace SitecSC.Presentation.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    
    
    [HttpGet(Name = "GetProducts")]
    [SwaggerOperation(Summary = "Get all products", OperationId = "GetProducts", Tags = new[] { "Product" },
        Description = "Get all products with her moves from the database and return them in a paginated list.")]
    [SwaggerResponse(200, "OK", typeof(List<ProductDto>))]
    public async Task<IActionResult> GetProducts(
        [FromQuery] ProductParameters productParameters)
    {
        var pagedResult = await _serviceManager.ProductService.GetProductsAsync(productParameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.products);
    }
    


    [HttpGet("{id:guid}", Name = "GetProductById")]
    [SwaggerOperation(Summary = "Get product by id", OperationId = "GetProductById", Tags = new[] { "Product" },
        Description = "Get product by id passed.")]
    [SwaggerResponse(200, "OK", typeof(ProductDto))]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _serviceManager.ProductService.GetProductByIdAsync(id, false);
        return Ok(product);
    }
    


    [HttpPost(Name = "CreateProduct")]
    [SwaggerOperation(Summary = "Create product", OperationId = "CreateProduct", Tags = new[] { "Product" },
        Description = "Create product.")]
    [SwaggerResponse(201, "Created", typeof(ProductDto))]
    [SwaggerResponse(400, "Bad request")]
    [SwaggerResponse(404, "Not found")]
    [SwaggerResponse(500, "Internal server error")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productDto)
    {
        var product = await _serviceManager.ProductService.CreateProductAsync(productDto);
        return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
    }
    


    [HttpPut("{id:guid}", Name = "UpdateProduct")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [SwaggerOperation(Summary = "Update product", OperationId = "UpdateProduct", Tags = new[] { "Product" },
        Description = "Update product.")]
    [SwaggerResponse(204, "OK", typeof(ProductDto))]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto productDto)
    {
        await _serviceManager.ProductService.UpdateProductAsync(id, productDto, true);
        return NoContent();
    }
    


    [HttpDelete("{id:guid}", Name = "DeleteProduct")]
    [SwaggerOperation(Summary = "Delete product", OperationId = "DeleteProduct", Tags = new[] { "Product" },
        Description = "Delete product.")]
    [SwaggerResponse(204, "OK", typeof(ProductDto))]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _serviceManager.ProductService.DeleteProductAsync(id, false);
        return NoContent();
    }

    
    
    [HttpPatch("{id:guid}")]
    [SwaggerOperation(Summary = "Partially update product", OperationId = "PartiallyUpdateProduct",
        Tags = new[] { "Product" }, Description = "Partially update product.")]
    [SwaggerResponse(204, "OK", typeof(ProductDto))]
    public async Task<IActionResult> PartiallyUpdateProduct(Guid id,
        [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
    {
        if (patchDoc is null) return BadRequest("patchDoc object sent from client is null.");
        var result = await _serviceManager.ProductService.GetProductForPatchAsync(id, true);
        patchDoc.ApplyTo(result.productToPatch, ModelState);
        TryValidateModel(result.productToPatch);
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        await _serviceManager.ProductService.SaveChangesForPatchAsync(result.productToPatch, result.productEntity);
        return NoContent();
    }
}