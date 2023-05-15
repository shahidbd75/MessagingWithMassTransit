using Microsoft.EntityFrameworkCore;
using MT.Publisher.Data;
using MT.Publisher.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("StoreDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var products = app.MapGroup("/products");

products.MapGet("/", ProductService.GetAllProductsAsync);

products.MapGet("/{name}", ProductService.GetProductsAsync);

products.MapPost("/", ProductService.AddProductAsync);

products.MapDelete("/{id}", ProductService.DeleteProductAsync);

app.Run();
