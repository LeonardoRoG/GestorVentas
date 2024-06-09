using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas.Repository;

public interface ICategoriaRepository
{
    Task<List<CategoriaDto>> GetAllCategorias();
    Task<CategoriaDto> GetCategoria(int idCategoria);
    void AddCategoria(CategoriaDto categoriaDto);
    void RemoveCategoria(int idCategoria);
    void UpdateCategoria(int idCategoria, CategoriaDto categoriaDto);
}

public class CategoriaRepository(AppDbContext context) : ICategoriaRepository
{
    public async void AddCategoria(CategoriaDto categoriaDto)
    {
        try
        {
            Categoria categoriaNueva = new()
            {
                Nombre = categoriaDto.Nombre,
                Descripcion = categoriaDto.Descripcion,
                UrlImagen = categoriaDto.UrlImagen
            };

            context.Add(categoriaNueva);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al agregar la categoría.", ex);
        }
    }

    public async Task<List<CategoriaDto>> GetAllCategorias()
    {
        var categorias = await context.Categorias.ToListAsync();
        return categorias.Adapt<List<CategoriaDto>>();
    }

    public async Task<CategoriaDto> GetCategoria(int idCategoria)
    {
        var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == idCategoria);
        return categoria.Adapt<CategoriaDto>();
    }

    public async void RemoveCategoria(int idCategoria)
    {
        try
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == idCategoria);
            if (categoria == null)
                throw new Exception($"La categoría no existe.");

            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar la categoría.", ex);
        }
    }

    public async void UpdateCategoria(int idCategoria, CategoriaDto categoriaDto)
    {
        try
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == idCategoria);
            if (categoria == null)
                throw new Exception($"La categoría no existe.");

            categoria.Nombre = categoriaDto.Nombre;
            categoria.UrlImagen = categoriaDto.UrlImagen;
            categoria.Descripcion = categoriaDto.Descripcion;

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar la categoría.", ex);
        }
    }
}
