using Application.Services;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GrupoMaxima.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProductDto>))]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductDto))]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Product not found.");

        var product = await _productService.GetByIdAsync(id);

        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create([FromBody] ProductDto product)
    {
        if (product is null || product.Code is null || product.Description is null || product.DepartmentId == Guid.Empty) 
            return BadRequest("Error trying to create new product.");

        await _productService.CreateAsync(product);

        return Created();
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductDto product)
    {
        if (id == Guid.Empty || product is null)
            return BadRequest("Invalid product.");

        await _productService.UpdateAsync(id, product);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        await _productService.DeleteAsync(id);

        return NoContent();
    }
}
