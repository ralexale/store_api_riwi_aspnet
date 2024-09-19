using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.Validators.Request;
using store_api_riwi.src.Domain;
using store_api_riwi.src.Domain.Entities;
using store_api_riwi.src.Domain.Repositories;
using store_api_riwi.src.Infrastructure.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Connection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserMapper>();
    cfg.AddProfile<OrderMapper>();
    cfg.AddProfile<ProductMapper>();
});

// Repositories
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

// Validators
builder.Services.AddScoped<IValidator<UserRequest>, UserValidatorRequest>();
builder.Services.AddScoped<IValidator<ProductRequest>, ProductValitatorRequest>();
builder.Services.AddScoped<IValidator<OrderRequest>, OrderValidatorRequest>();

builder.Services.AddControllers();
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
