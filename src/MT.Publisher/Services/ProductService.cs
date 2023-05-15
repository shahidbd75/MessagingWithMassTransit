using Microsoft.EntityFrameworkCore;
using MT.Publisher.Data;
using MT.Publisher.Data.Models;

namespace MT.Publisher.Services
{
    public static class ProductService
    {
        public static async Task<IResult> AddProductAsync(Product product, StoreDbContext context)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return Results.Created($"products/{product.Name}", product);
        }

        public static async Task<IResult> GetAllProductsAsync(StoreDbContext context)
        {
            return Results.Ok(await context.Products.ToListAsync());
        }

        public static async Task<IResult> GetProductsAsync(string name, StoreDbContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == name);
            
            
            return product != null ? Results.Ok(product): Results.NotFound();
        }

        public static async Task<IResult> DeleteProductAsync(int id, StoreDbContext context)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
                return TypedResults.NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return TypedResults.NoContent();
        }
    }
}
