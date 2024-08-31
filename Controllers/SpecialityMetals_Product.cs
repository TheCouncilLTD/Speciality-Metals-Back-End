using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Product : ControllerBase
    { 
     private readonly IProduct_Repository _repository;

    public SpecialityMetals_Product(IProduct_Repository repository)
    {
        _repository = repository;
    }

    // GET: api/SpecialityMetals_Product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _repository.GetAllProductsAsync();
        return Ok(products);
    }

    // GET: api/SpecialityMetals_Product/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST: api/SpecialityMetals_Product
    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        var createdProduct = await _repository.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductID }, createdProduct);
    }

    // PUT: api/SpecialityMetals_Product/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.ProductID)
        {
            return BadRequest();
        }

        var updatedProduct = await _repository.UpdateProductAsync(product);
        if (updatedProduct == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/SpecialityMetals_Product/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _repository.DeleteProductAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
}