using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas.Repository;

public interface IProductoRepository
{
    Task<List<ProductoDto>> GetAllProductos();
    Task<ProductoDto> GetProducto(int idProducto);
    void AddProducto(ProductoDto productoDto);
    void RemoveProducto(int idProducto);
    void UpdateProducto(int idProducto, ProductoDto productoDto);
}

public class ProductoRepository(AppDbContext context) : IProductoRepository
{
    public async void AddProducto(ProductoDto productoDto)
    {
        try
        {
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == productoDto.Categoria.IdCategoria);
            var proveedor = await context.Proveedores.FirstOrDefaultAsync(x => x.IdProveedor == productoDto.Proveedor.IdProveedor);
        
            Producto productoNuevo = new()
            {
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                UrlImagen = productoDto.UrlImagen,
                Stock = productoDto.Stock,
                Precio = productoDto.Precio,
                Discontinuado = false,
                Categoria = categoria!,
                Proveedor = proveedor!
            };

            context.Add(productoNuevo);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al agregar el producto.", ex);
        }
    }

    public async Task<List<ProductoDto>> GetAllProductos()
    {
        var productos = await context.Productos
                            .Include(x => x.Proveedor)
                            .Include(x => x.Categoria)
                            .ToListAsync();

        return productos.Adapt<List<ProductoDto>>();
    }

    public async Task<ProductoDto> GetProducto(int idProducto)
    {
        var producto = await context.Productos.Where(x => x.IdProducto == idProducto)
                                     .Include(x => x.Proveedor)
                                     .Include(x => x.Categoria)
                                     .FirstOrDefaultAsync();

        return producto.Adapt<ProductoDto>();
    }

    public async void RemoveProducto(int idProducto)
    {
        try
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.IdProducto == idProducto) ?? throw new Exception($"El producto con id {idProducto} no existe.");
            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al remover el producto.", ex);
        }
    }

    public async void UpdateProducto(int idProducto, ProductoDto productoDto)
    {
        try
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.IdProducto == idProducto) ?? throw new Exception($"El producto con id {idProducto} no existe.");
            var categoria = await context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == productoDto.Categoria.IdCategoria);
            var proveedor = await context.Proveedores.FirstOrDefaultAsync(x => x.IdProveedor == productoDto.Proveedor.IdProveedor);

            producto.Nombre = productoDto.Nombre;
            producto.Descripcion = productoDto.Descripcion;
            producto.UrlImagen = productoDto.UrlImagen;
            producto.Stock = productoDto.Stock;
            producto.Precio = productoDto.Precio;
            producto.Discontinuado = false;
            producto.Categoria = categoria!;
            producto.Proveedor = proveedor!;

            await context.SaveChangesAsync();
        }
        catch (Exception ex) 
        {
            throw new Exception("Error al actualizar el producto.", ex);
        }

        //// Otra forma de ejecutar un update
        //var rowsAffected = context.Productos.Where(x => x.IdProducto == idProducto)
        //    .ExecuteUpdate(update =>
        //        update.SetProperty(entity => entity.Nombre, productoDto.Nombre)
        //              .SetProperty(entity => entity.Descripcion, productoDto.Descripcion)
        //              .SetProperty(entity => entity.UrlImagen, productoDto.UrlImagen)
        //              .SetProperty(entity => entity.Stock, productoDto.Stock)
        //              .SetProperty(entity => entity.Precio, productoDto.Precio)
        //              .SetProperty(entity => entity.Discontinuado, productoDto.Discontinuado)
        //              .SetProperty(entity => entity.Categoria, categoria)
        //              .SetProperty(entity => entity.Proveedor, proveedor));
    }
}
