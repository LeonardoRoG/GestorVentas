using Carter;
using GestorVentas.Endpoints.DTO;
using GestorVentas.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentas.Endpoints;

public class ProveedorEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/proveedor");

        app.MapGet("/", (IProveedorService proveedorService) =>
        {
            var proveedores = proveedorService.GetAllProveedors();
            return Results.Ok(proveedores);

        }).WithTags("Proveedor");

        app.MapGet("/{idProveedor:int}", (IProveedorService proveedorService, int idProveedor) =>
        {
            var proveedor = proveedorService.GetProveedor(idProveedor);
            return Results.Ok(proveedor);

        }).WithTags("Proveedor");

        app.MapPost("/", ([FromServices]IProveedorService proveedorService, [FromBody]ProveedorRequestDto proveedorDto) =>
        {
            proveedorService.AddProveedor(proveedorDto);
            return Results.Created();

        }).WithTags("Proveedor");

        app.MapDelete("/{idProveedor:int}", (IProveedorService proveedorService, int idProveedor) =>
        {
            proveedorService.RemoveProveedor(idProveedor);
            return Results.NoContent();

        }).WithTags("Proveedor");

        app.MapPut("/{idProveedor}", (IProveedorService proveedorService, int idProveedor, ProveedorRequestDto proveedorDto) =>
        {
            proveedorService.UpdateProveedor(idProveedor, proveedorDto);
            return Results.Ok();

        }).WithTags("Proveedor");

    }
}
