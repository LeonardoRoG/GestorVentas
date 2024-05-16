using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Categoria")]
public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    [StringLength(30)]
    public required string Nombre { get; set; }

    [StringLength(200)]
    public string? UrlImagen { get; set; }

    [StringLength(50)]
    public string? Descripcion { get; set; }

    public List<Producto> Productos { get; set; } = [];
}
