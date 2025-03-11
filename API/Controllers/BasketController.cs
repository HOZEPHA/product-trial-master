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
    public async Task<ActionResult<int>> GetBasketCount()
    {
        var basket = await context.Baskets
            .Include(b => b.BasketItem) // Ensure related items are loaded
            .FirstOrDefaultAsync(b => b.BuyerEmail == "admin@admin.fr"); // Check if basket exists

        if (basket == null)
        {
            return NotFound("Basket not found for the given buyer email.");
        }

        int itemCount = basket.BasketItem.Count; // Safely count items

        return Ok(itemCount);
    }



}
