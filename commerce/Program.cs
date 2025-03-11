using commerce.Models;
using commerce.Aspects;
using commerce.Repository;
using commerce.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ExceptionHandlerAttribute>();

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
