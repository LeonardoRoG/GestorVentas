using Carter;
using GestorVentas.Service;

namespace GestorVentas.Endpoints;

public class ProveedorEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/proveedor");

        app.MapGet("/", (IProveedorService proveedorService) =>
        {

        }).WithTags("Proveedor");
    }
}
