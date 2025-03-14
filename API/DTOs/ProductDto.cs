namespace API;

/// <summary>
/// This class represents a product entity.
/// </summary>
public class ProductDto
{
    /// <summary>
    /// This is the auto-incremented primary key of the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This property is used to store the product's code.
    /// This must be set during object initialization.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// This property is used to store the name of the product.
    /// This must be set during object initialization.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// This property stores a detailed description of the product.
    /// This must be set during object initialization.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// This property stores the image URL for the product.
    /// This must be set during object initialization.
    /// </summary>
    public required string Image { get; set; }

    /// <summary>
    /// This property stores the category name of the product.
    /// This must be set during object initialization.
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// This property stores the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// This property stores the quantity available in stock.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// This property is used to store the internal reference identifier of the product.
    /// This must be set during object initialization.
    /// </summary>
    public required string InternalReference { get; set; }

    /// <summary>
    /// This property stores the shell identifier for the product.
    /// </summary>
    public int ShellId { get; set; }

    /// <summary>
    /// This property stores the inventory status of the product.
    /// </summary>
    public required string InventoryStatus { get; set; }

    /// <summary>
    /// This property stores the average rating of the product.
    /// </summary>
    public double Rating { get; set; }
    /// This property stores the creation date and time of the product.
    /// </summary>
    public long CreatedAt { get; set; }

    /// <summary>
    /// This property stores the last updated date and time of the product.
    /// </summary>
    public long UpdatedAt { get; set; }

}

