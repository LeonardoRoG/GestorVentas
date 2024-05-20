using Carter;
using GestorVentas.Service;

namespace GestorVentas.Endpoints;

public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Categorias");

        app.MapGet("/", (ICategoriaService categoriaService) =>
        {
            var categorias = categoriaService.GetAllCategorias();
            return Results.Ok(categorias);

        }).WithTags("Categorias");
    }
}
