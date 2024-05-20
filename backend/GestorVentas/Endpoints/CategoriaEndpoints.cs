using Carter;
using GestorVentas.Endpoints.DTO;
using GestorVentas.Service;
using Microsoft.AspNetCore.Mvc;

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

        app.MapGet("/{idCategoria:int}", (ICategoriaService categoriaService, int idCategoria) =>
        {
            var categoria = categoriaService.GetCategoria(idCategoria);
            return Results.Ok(categoria);

        }).WithTags("Categorias");

        app.MapPost("/", ([FromServices]ICategoriaService categoriaService, [FromBody]CategoriaRequestDto categoriaDto) =>
        {
            categoriaService.AddCategoria(categoriaDto);
            return Results.Created();

        }).WithTags("Categorias");

        app.MapDelete("/{idCategoria:int}", (ICategoriaService categoriaService, int idCategoria) =>
        {
            categoriaService.RemoveCategoria(idCategoria);
            return Results.NoContent();

        }).WithTags("Categorias");

        app.MapPut("/", ([FromServices]ICategoriaService categoriaService, int idCategoria, [FromBody]CategoriaRequestDto categoriaDto) =>
        {
            categoriaService.UpdateCategoria(idCategoria, categoriaDto);
            return Results.Ok();

        }).WithTags("Categorias");
    }
}
