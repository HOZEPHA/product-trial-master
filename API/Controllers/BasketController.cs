using System.Security.Claims;
using API.Data;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class BasketController(DataContext context) : BaseApiController
{
    //TODO : Use CQRS pattern query to get a product by its ID
    /// <summary>
    /// This method returns a single product by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("itemCount")]
    public async Task<ActionResult<Basket>> GetBasketCount()
    {
        var basket = await context.Baskets
    .Where(b => b.BuyerEmail == "admin@admin.fr")
    .SelectMany(b => b.BasketItem) // Flatten BasketItem lists
    .CountAsync(); // Count the total items

        if (basket == 0)
        {
            return NotFound();
        }
        return Ok(basket);
    }


}
