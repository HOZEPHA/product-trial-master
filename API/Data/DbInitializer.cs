using System.Security.Cryptography;
using System.Text;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DbInitializer
{
    public static async Task CleanAsync(DataContext context)
    {
        // Deleting all records from all tables. You can adjust this according to your needs.
        context.Products.RemoveRange(context.Products);
        context.Users.RemoveRange(context.Users);

        await context.SaveChangesAsync();
    }
    public static async Task SeedAsync(DataContext context)
    {
        // Apply any pending migrations
        await context.Database.MigrateAsync();

        // Seed Users (if not already created)
        if (!context.Users.Any())
        {
            using var hmac = new HMACSHA3_512();
            var user = new AppUser
            {
                Email = "admin@admin.fr",
                UserName = "admin@admin.fr",
                FirstName = "Admin",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Admin1234")),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);

            await context.SaveChangesAsync();
        }

        // Seed Products (if not already created)
        if (!context.Products.Any())
        {
            var products = new List<Product>
    {
new Product { Code = "f230fh0g3", Name = "Bamboo Watch", Description = "A sleek and eco-friendly bamboo watch that combines nature with elegance. Perfect for those who want to make a statement while staying environmentally conscious.", Price = 65m, Category = "Accessories", Image = "bamboo-watch.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow },
new Product { Code = "nvklal433", Name = "Black Watch", Description = "A stylish black watch with a minimalist design, ideal for any occasion. Its versatility ensures it will pair well with both casual and formal wear.", Price = 72m, Category = "Accessories", Image = "black-watch.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "zz21cz3c1", Name = "Blue Band", Description = "This durable blue fitness band tracks your steps, heart rate, and calories burned, helping you stay on top of your health and fitness goals.", Price = 79m, Category = "Fitness", Image = "blue-band.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.LOWSTOCK, Rating = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "244wgerg2", Name = "Blue T-Shirt", Description = "A soft and comfortable blue t-shirt made from high-quality cotton, perfect for those laid-back weekends or casual outings.", Price = 29m, Category = "Clothing", Image = "blue-t-shirt.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "h456wer53", Name = "Bracelet", Description = "This elegant bracelet features a simple yet sophisticated design, making it a perfect accessory for any occasion, from casual to formal.", Price = 15m, Category = "Accessories", Image = "bracelet.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "av2231fwg", Name = "Brown Purse", Description = "A timeless brown purse with a classic design, offering plenty of space for your essentials. It's the perfect companion for everyday use.", Price = 120m, Category = "Accessories", Image = "brown-purse.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.OUTOFSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "bib36pfvm", Name = "Chakra Bracelet", Description = "This chakra bracelet is designed to promote balance and positive energy. A must-have for those seeking spiritual harmony and a unique fashion statement.", Price = 32m, Category = "Accessories", Image = "chakra-bracelet.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.LOWSTOCK, Rating = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "mbvjkgip5", Name = "Galaxy Earrings", Description = "These galaxy-inspired earrings bring a touch of the cosmos to your look. Sparkling with vibrant colors, they make a statement wherever you go.", Price = 34m, Category = "Accessories", Image = "galaxy-earrings.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "vbb124btr", Name = "Game Controller", Description = "A high-performance game controller designed for precision and comfort. Elevate your gaming experience with responsive controls and ergonomic design.", Price = 99m, Category = "Electronics", Image = "game-controller.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.LOWSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "cm230f032", Name = "Gaming Set", Description = "This all-in-one gaming set includes everything you need to take your gaming to the next level, featuring a high-quality headset, mouse, and keyboard.", Price = 299m, Category = "Electronics", Image = "gaming-set.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "plb34234v", Name = "Gold Phone Case", Description = "Add a touch of luxury to your device with this stunning gold phone case. Its sleek design offers protection while keeping your phone looking stylish.", Price = 24m, Category = "Accessories", Image = "gold-phone-case.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.OUTOFSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "4920nnc2d", Name = "Green Earbuds", Description = "These sleek green earbuds provide crisp sound quality, making them perfect for music lovers and podcast enthusiasts. Comfortable, portable, and stylish.", Price = 89m, Category = "Electronics", Image = "green-earbuds.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "250vm23cc", Name = "Green T-Shirt", Description = "This vibrant green t-shirt is made from soft, breathable cotton, perfect for hot days or casual outings with friends. A wardrobe essential.", Price = 49m, Category = "Clothing", Image = "green-t-shirt.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "fldsmn31b", Name = "Grey T-Shirt", Description = "A simple yet stylish grey t-shirt that pairs well with everything in your wardrobe. Comfort and casual style, all in one.", Price = 48m, Category = "Clothing", Image = "grey-t-shirt.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.OUTOFSTOCK, Rating = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "waas1x2as", Name = "Headphones", Description = "High-quality headphones with noise-cancellation features. Perfect for music lovers who demand superior sound without distractions.", Price = 175m, Category = "Electronics", Image = "headphones.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.LOWSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "vb34btbg5", Name = "Light Green T-Shirt", Description = "A fresh and cool light green t-shirt, perfect for a relaxed day out. The soft fabric makes it comfortable for all-day wear.", Price = 49m, Category = "Clothing", Image = "light-green-t-shirt.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "k8l6j58jl", Name = "Lime Band", Description = "This lively lime band is a great way to stay motivated during workouts. With its flexible design, it offers both comfort and style.", Price = 79m, Category = "Fitness", Image = "lime-band.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "v435nn85n", Name = "Mini Speakers", Description = "Portable mini speakers that deliver big sound. Take them anywhere and enjoy music, podcasts, or videos on the go with amazing audio clarity.", Price = 85m, Category = "Clothing", Image = "mini-speakers.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "09zx9c0zc", Name = "Painted Phone Case", Description = "This unique phone case is hand-painted with vibrant designs, offering a fun and artistic way to protect your phone from scratches and drops.", Price = 56m, Category = "Accessories", Image = "painted-phone-case.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "mnb5mb2m5", Name = "Pink Band", Description = "A stylish pink fitness band that tracks your activity and keeps you motivated to stay active. The perfect balance of form and function.", Price = 79m, Category = "Fitness", Image = "pink-band.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "r23fwf2w3", Name = "Pink Purse", Description = "This chic pink purse is designed for those who appreciate both style and practicality. Perfect for holding your essentials while staying fashionable.", Price = 110m, Category = "Accessories", Image = "pink-purse.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.OUTOFSTOCK, Rating = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "pxpzczo23", Name = "Purple Band", Description = "A stylish purple fitness band that not only tracks your health metrics but also adds a pop of color to your fitness routine.", Price = 79m, Category = "Fitness", Image = "purple-band.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.LOWSTOCK, Rating = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
new Product { Code = "2c42cbvxc", Name = "Silver Necklace", Description = "A delicate silver necklace that adds a touch of sophistication to any outfit. The perfect accessory for both formal and casual occasions.", Price = 98m, Category = "Accessories", Image = "silver-necklace.jpg", InternalReference = "REF-123-456", ShellId = 15, InventoryStatus = InventoryStatus.INSTOCK, Rating = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }

    };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }

        //Seed an item into the basket table
        if (!context.Baskets.Any())
        {
            var user = await context.Users.FirstOrDefaultAsync(c => c.Email == "admin@admin.fr");
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var product = await context.Products.SingleOrDefaultAsync(c => c.Code == "f230fh0g3");
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            var basket = new Basket
            {
                BuyerEmail = user.Email,
                BasketItem = new List<BasketItem>
    {
        new BasketItem
        {
            ProductId = product.Id,
            Quantity = 1,
            Price = product.Price,
            ProductName = product.Name,
            ImageUrl = product.Image
        }
    }
            };

            context.Baskets.Add(basket);
            await context.SaveChangesAsync();

        }
    }
}
