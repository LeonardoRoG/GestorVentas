using Carter;
using GestorVentas.Endpoints.DTO;
using GestorVentas.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentas.Endpoints;

public class VehiculoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Vehiculos");

        app.MapGet("/", (IVehiculoService vehiculoService) =>
        {
            var vehiculos = vehiculoService.GetAllVehiculos();
            return Results.Ok(vehiculos);

        }).WithTags("Vehiculos");
        
        app.MapGet("/{idVehiculo:int}", (IVehiculoService vehiculoService, int idVehiculo) =>
        {
            var vehiculo = vehiculoService.GetVehiculo(idVehiculo);
            return Results.Ok(vehiculo);

        }).WithTags("Vehiculos");
        
        app.MapPost("/", (IVehiculoService vehiculoService, [FromBody]VehiculoRequestDto vehiculoDto) =>
        {
            vehiculoService.AddVehiculo(vehiculoDto);
            return Results.Created();

        }).WithTags("Vehiculos");
        
        app.MapDelete("/{idVehiculo:int}", (IVehiculoService vehiculoService, int idVehiculo) =>
        {
            vehiculoService.RemoveVehiculo(idVehiculo);
            return Results.NoContent();

        }).WithTags("Vehiculos");
        
        app.MapPut("/{idVehiculo:int}", (IVehiculoService vehiculoService, int idVehiculo, VehiculoRequestDto vehiculoDto) =>
        {
            vehiculoService.UpdateVehiculo(idVehiculo, vehiculoDto);
            return Results.Ok();

        }).WithTags("Vehiculos");


    }
}
