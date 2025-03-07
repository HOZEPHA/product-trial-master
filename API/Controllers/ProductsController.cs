using API.Data;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductsController(DataContext context, IMapper mapper) : BaseApiController
{
  /// <summary>
  /// This method returns a list of all products.
  /// Each user even not authenticated can call this method.
  /// </summary>
  /// <returns></returns>
  [AllowAnonymous]
  [HttpGet]
  public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
  {
    var Products = await context.Products.ToListAsync();

    // Use AutoMapper to map products to ProductDto
    var productDtos = mapper.Map<List<ProductDto>>(Products);

    return Ok(productDtos);
  }

  /// <summary>
  /// This method returns a single product by its ID.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet("{id:int}")]
  public async Task<ActionResult<Product>> GetProducts(int id)
  {
    var Product = await context.Products.FindAsync(id);
    if (Product == null) return NotFound();
    return Ok(Product);
  }

  // PUT: api/products/1000
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
  {
    if (id != updatedProduct.Id)
    {
      return BadRequest("Product ID mismatch");
    }

    var product = await context.Products.FindAsync(id);
    if (product == null)
    {
      return NotFound();
    }

    // Update product fields
    product.Name = updatedProduct.Name;
    product.Description = updatedProduct.Description;
    product.Price = updatedProduct.Price;
    product.Quantity = updatedProduct.Quantity;
    product.Category = updatedProduct.Category;
    product.Image = updatedProduct.Image;
    product.InternalReference = updatedProduct.InternalReference;
    product.ShellId = updatedProduct.ShellId;
    product.InventoryStatus = updatedProduct.InventoryStatus;
    product.Rating = updatedProduct.Rating;
    product.UpdatedAt = DateTime.UtcNow;

    // Save changes to the database
    await context.SaveChangesAsync();

    return NoContent(); // Return 204 No Content on success
  }

  // DELETE: api/products/1000
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(int id)
  {
    var product = await context.Products.FindAsync(id);
    if (product == null)
    {
      return NotFound();
    }

    // Remove the product from the database
    context.Products.Remove(product);
    await context.SaveChangesAsync();

    return NoContent(); // Return 204 No Content on success
  }
}
