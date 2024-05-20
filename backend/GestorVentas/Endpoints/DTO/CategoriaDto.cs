namespace GestorVentas.Endpoints.DTO;

public class CategoriaDto
{
    public int IdCategoria { get; set; }
    public required string Nombre { get; set; }
    public string? UrlImagen { get; set; }
    public string? Descripcion { get; set; }
}

public class CategoriaRequestDto
{
    public required string Nombre { get; set; }
    public string? UrlImagen { get; set; }
    public string? Descripcion { get; set; }
}

public class CategoriaResponseDto
{
    public int IdCategoria { get; set; }
    public required string Nombre { get; set; }
    public string? UrlImagen { get; set; }
    public string? Descripcion { get; set; }
}

