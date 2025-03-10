using API;
using API.Data;
using API.Extensions;
using API.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(ProductProfile)); // Automatically loads profiles in this class

var app = builder.Build();

// Create a scope for dependency injection
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DataContext>();

        //Clean Db
        await DbInitializer.CleanAsync(context);

        // Seed data
        await DbInitializer.SeedAsync(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError($"Error seeding data: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
   .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
    
app.Run();
