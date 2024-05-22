using GestorVentas.Endpoints.DTO;
using GestorVentas.Repository;
using Mapster;

namespace GestorVentas.Service;

public interface IProductoService
{
    List<ProductoResponseDto> GetAllProductos();
    ProductoResponseDto GetProducto(int idProducto);
    void AddProducto(ProductoRequestDto productoDto);
    void RemoveProducto(int idProducto);
    void UpdateProducto(int idProducto, ProductoRequestDto productoDto);
}

public class ProductoService(IProductoRepository productoRepository) : IProductoService
{
    public void AddProducto(ProductoRequestDto productoDto)
    {
        productoRepository.AddProducto(productoDto.Adapt<ProductoDto>());
    }

    public List<ProductoResponseDto> GetAllProductos()
    {
        return productoRepository.GetAllProductos().Adapt<List<ProductoResponseDto>>();
    }

    public ProductoResponseDto GetProducto(int idProducto)
    {
        return productoRepository.GetProducto(idProducto).Adapt<ProductoResponseDto>();
    }

    public void RemoveProducto(int idProducto)
    {
        productoRepository.RemoveProducto(idProducto);
    }

    public void UpdateProducto(int idProducto, ProductoRequestDto productoDto)
    {
        productoRepository.UpdateProducto(idProducto, productoDto.Adapt<ProductoDto>());
    }
}
