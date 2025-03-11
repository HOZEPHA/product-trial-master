namespace API.Entities;

/// <summary>
/// This class represents a product entity.
/// </summary>
public class Basket
{
    /// <summary>
    /// This is the auto-incremented primary key of the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This property is used to store the buyer's identifier.
    /// </summary>
    public required string BuyerEmail { get; set; }

    /// <summary>
    /// This property is used to store the list of items in the basket.
    /// </summary>
    public required List<BasketItem> BasketItem { get; set; }

}


