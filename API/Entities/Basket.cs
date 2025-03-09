// using System;
// using System.Text.Json.Serialization;

// namespace API.Entities
// {
//     /// <summary>
//     /// This class represents a product entity.
//     /// </summary>
//     public class Basket
//     {
//         /// <summary>
//         /// This is the auto-incremented primary key of the product.
//         /// </summary>
//         public int Id { get; set; }

//         public IEnumerable<BasketItem> Items { get; set; }  
        
//     }

//     public class BasketItem
//     {
//         public int Id { get; set; }
//         public int ProductId { get; set; }
//         public string ProductName { get; set; }
//         public decimal Price { get; set; }
//         public int Quantity { get; set; }
//         public string Image { get; set; }
//     }
// }
