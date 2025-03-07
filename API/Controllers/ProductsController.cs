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
}