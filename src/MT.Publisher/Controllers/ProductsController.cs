using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MT.Publisher.Data;
using MT.Publisher.Data.Models;
using MT.Publisher.Dtos;

namespace MT.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public ProductsController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IResult> GetAllAsync()
        {
            return TypedResults.Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetByIdAsync([Required][FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return TypedResults.NoContent();

            return TypedResults.Ok();
        }

        [HttpPost]
        public async Task<IResult> AddAsync([FromBody]ProductRequestModel requestModel)
        {
            var product = new Product
                {Id = requestModel.Id, Name = requestModel.Name, CategoryId = requestModel.CategoryId};

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return TypedResults.Created($"product/{product.Id}", product);
        }
    }
}
