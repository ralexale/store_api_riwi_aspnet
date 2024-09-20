using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Api.Validators.Request;
using store_api_riwi.src.Domain;
using store_api_riwi.src.Domain.Entities;
using store_api_riwi.src.Domain.Repositories;
using store_api_riwi.src.Infrastructure.AbstractServices;
using store_api_riwi.src.Infrastructure.Mappers;
using store_api_riwi.src.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura AutoMapper con perfiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserMapper>();
    cfg.AddProfile<OrderMapper>();
    cfg.AddProfile<ProductMapper>();
});

// Configura los Repositorios
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();


// common service

builder.Services.AddScoped<ICommonService<UserResponse, UserRequest>, UserService>();
builder.Services.AddScoped<ICommonService<ProductResponse, ProductRequest>, ProductService>();
builder.Services.AddScoped<ICommonService<OrderResponse, OrderRequest>, OrderService>();


// Configura los Validadores
builder.Services.AddScoped<IValidator<UserRequest>, UserValidatorRequest>();
builder.Services.AddScoped<IValidator<ProductRequest>, ProductValitatorRequest>(); // Corrección de nombre
builder.Services.AddScoped<IValidator<OrderRequest>, OrderValidatorRequest>();

// Configura Entity Framework con MySQL
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Connection"),
        new MySqlServerVersion(new Version(8, 4, 0))); // Corrección de versión de MySQL
});

builder.Services.AddControllers();

// Configura Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
