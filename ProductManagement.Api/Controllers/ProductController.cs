using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Models;
using ProductManagement.Api.Service;

namespace ProductManagement.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts([FromQuery] string? name, [FromQuery] string? sortBy)
    {
        var products = _productService.GetAll(name, sortBy);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetById(id);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] Product product)
    {
        var addedProduct = _productService.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = addedProduct.Id }, addedProduct);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product product)
    {
        var updatedProduct = _productService.Update(id, product);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        _productService.Delete(id);
        return NoContent();
    }
}