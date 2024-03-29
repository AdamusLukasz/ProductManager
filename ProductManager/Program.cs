using Microsoft.EntityFrameworkCore;
using ProductManager.Entities;
using ProductManager.Services;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductManager")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShopService, ShopService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
