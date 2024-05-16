using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Producto")]
public class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [StringLength(50)]
    public required string Nombre { get; set; }

    [StringLength(50)]
    public string? Descripcion { get; set; }

    [StringLength(200)]
    public string? UrlImagen { get; set; }

    public int Stock { get; set; } = 0;

    public required decimal Precio { get; set; }

    public bool Discontinuado { get; set; } = false;

    [ForeignKey("IdProveedor")]
    public required Proveedor Proveedor { get; set; }

    [ForeignKey("IdCategoria")]
    public required Categoria Categoria { get; set; }

    public List<DetalleOrden> DetallesOrdenes { get; set; } = [];
}
