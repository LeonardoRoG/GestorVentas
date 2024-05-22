namespace GestorVentas.Endpoints.DTO;

public class ProductoDto
{
    public int IdProducto { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion {  get; set; }
    public string? UrlImagen { get; set; }
    public int Stock { get; set; }
    public required decimal Precio { get; set; }
    public bool Discontinuado { get; set; }
    public required ProveedorDto Proveedor { get; set; }
    public required CategoriaDto Categoria { get; set; }
}

public class ProductoRequestDto
{
    public required string Nombre { get; set; }
    public string? Descripcion {  get; set; }
    public string? UrlImagen { get; set; }
    public int Stock { get; set; }
    public required decimal Precio { get; set; }
    public bool Discontinuado { get; set; }
    public required ProveedorProductoRequestDto Proveedor { get; set; }
    public required CategoriaProductoRequestDto Categoria { get; set; }
}

public class ProductoResponseDto
{
    public int IdProducto { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion {  get; set; }
    public string? UrlImagen { get; set; }
    public int Stock { get; set; }
    public required decimal Precio { get; set; }
    public bool Discontinuado { get; set; }
    public required ProveedorResponseDto Proveedor { get; set; }
    public required CategoriaResponseDto Categoria { get; set; }
}