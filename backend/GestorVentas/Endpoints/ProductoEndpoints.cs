using Carter;
using GestorVentas.Endpoints.DTO;
using GestorVentas.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentas.Endpoints;

public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Productos");

        app.MapGet("/", (IProductoService productoService) =>
        {
            var productos = productoService.GetAllProductos();
            return Results.Ok(productos);

        }).WithTags("Productos");

        app.MapGet("/{idProducto:int}", (IProductoService productoService, int idProducto) =>
        {
            var producto = productoService.GetProducto(idProducto);
            return Results.Ok(producto);

        }).WithTags("Productos");
        
        app.MapPost("/", (IProductoService productoService, [FromBody]ProductoRequestDto productoDto) =>
        {
            productoService.AddProducto(productoDto);
            return Results.Created();

        }).WithTags("Productos");

        app.MapDelete("/{idProducto:int}", (IProductoService productoService, int idProducto) =>
        {
            productoService.RemoveProducto(idProducto);
            return Results.NoContent();

        }).WithTags("Productos");

        app.MapPut("/{idProducto:int}", ([FromServices]IProductoService productoService, int idProducto, [FromBody]ProductoRequestDto productoDto) =>
        {
            productoService.UpdateProducto(idProducto, productoDto);
            return Results.Ok();

        }).WithTags("Productos");

    }
}
