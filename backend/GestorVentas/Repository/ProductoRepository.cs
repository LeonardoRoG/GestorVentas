using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas.Repository;

public interface IProductoRepository
{
    List<ProductoDto> GetAllProductos();
    ProductoDto GetProducto(int idProducto);
    void AddProducto(ProductoDto productoDto);
    void RemoveProducto(int idProducto);
    void UpdateProducto(int idProducto, ProductoDto productoDto);
}

public class ProductoRepository(AppDbContext context) : IProductoRepository
{
    public void AddProducto(ProductoDto productoDto)
    {
        var categoria = context.Categorias.FirstOrDefault(x => x.IdCategoria == productoDto.Categoria.IdCategoria);
        var proveedor = context.Proveedores.FirstOrDefault(x => x.IdProveedor == productoDto.Proveedor.IdProveedor);
        
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
        context.SaveChanges();
    }

    public List<ProductoDto> GetAllProductos()
    {
        var productos = context.Productos
                            .Include(x => x.Proveedor)
                            .Include(x => x.Categoria)
                            .ToList();

        return productos.Adapt<List<ProductoDto>>();
    }

    public ProductoDto GetProducto(int idProducto)
    {
        var producto = context.Productos.Where(x => x.IdProducto == idProducto)
                                     .Include(x => x.Proveedor)
                                     .Include(x => x.Categoria)
                                     .FirstOrDefault();

        return producto.Adapt<ProductoDto>();
    }

    public void RemoveProducto(int idProducto)
    {
        var producto = context.Productos.FirstOrDefault(x => x.IdProducto == idProducto);
        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe.");

        context.Productos.Remove(producto);
        context.SaveChanges();
    }

    public void UpdateProducto(int idProducto, ProductoDto productoDto)
    {
        var producto = context.Productos.FirstOrDefault(x => x.IdProducto == idProducto);
        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe.");
        
        var categoria = context.Categorias.FirstOrDefault(x => x.IdCategoria == productoDto.Categoria.IdCategoria);
        var proveedor = context.Proveedores.FirstOrDefault(x => x.IdProveedor == productoDto.Proveedor.IdProveedor);

        producto.Nombre = productoDto.Nombre;
        producto.Descripcion = productoDto.Descripcion;
        producto.UrlImagen = productoDto.UrlImagen;
        producto.Stock = productoDto.Stock;
        producto.Precio = productoDto.Precio;
        producto.Discontinuado = false;
        producto.Categoria = categoria!;
        producto.Proveedor = proveedor!;

        context.SaveChanges();

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
