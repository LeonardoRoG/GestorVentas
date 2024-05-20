using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;

namespace GestorVentas.Repository;

public interface ICategoriaRepository
{
    List<CategoriaDto> GetAllCategorias();
    CategoriaDto GetCategoria(int idCategoria);
    void AddCategoria(CategoriaDto categoriaDto);
    void RemoveCategoria(int idCategoria);
    void UpdateCategoria(int idCategoria, CategoriaDto categoriaDto);
}

public class CategoriaRepository(AppDbContext context) : ICategoriaRepository
{
    public void AddCategoria(CategoriaDto categoriaDto)
    {
        Categoria categoriaNueva = new()
        {
            Nombre = categoriaDto.Nombre,
            Descripcion = categoriaDto.Descripcion,
            UrlImagen = categoriaDto.UrlImagen
        };

        context.Add(categoriaNueva);
        context.SaveChanges();
    }

    public List<CategoriaDto> GetAllCategorias()
    {
        var categorias = context.Categorias.ToList();
        return categorias.Adapt<List<CategoriaDto>>();
    }

    public CategoriaDto GetCategoria(int idCategoria)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.IdCategoria == idCategoria);
        return categoria.Adapt<CategoriaDto>();
    }

    public void RemoveCategoria(int idCategoria)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.IdCategoria == idCategoria);
        if (categoria == null)
            throw new Exception($"La categoría no existe.");

        context.Categorias.Remove(categoria);
        context.SaveChanges();
    }

    public void UpdateCategoria(int idCategoria, CategoriaDto categoriaDto)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.IdCategoria == idCategoria);
        if (categoria == null)
            throw new Exception($"La categoría no existe.");

        categoria.Nombre = categoriaDto.Nombre;
        categoria.UrlImagen = categoriaDto.UrlImagen;
        categoria.Descripcion = categoriaDto.Descripcion;

        context.SaveChanges();
    }
}
