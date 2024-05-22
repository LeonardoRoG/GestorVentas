using Carter;
using GestorVentas.Database;
using GestorVentas.Repository;
using GestorVentas.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

builder.Services.AddCarter();

// Add CORS configuration
builder.Services.AddCors(options => options.AddPolicy("GestorVentas2024",
    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(config.GetConnectionString("AppDb")));

builder.Services.AddTransient<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddTransient<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option => option.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();

// Using CORS
app.UseCors("GestorVentas2024");

app.MapCarter();

app.Run();
