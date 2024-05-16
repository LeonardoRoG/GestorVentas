using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("DetalleOrden")]
public class DetalleOrden
{
    [Key]
    public int IdDetalleOrden {  get; set; }

    public int Cantidad { get; set; } = 1;

    [ForeignKey("IdProducto")]
    public required Producto Producto { get; set; }

    [ForeignKey("IdOrden")]
    public required Orden Orden { get; set; }

    public decimal Subtotal() => Producto.Precio * Cantidad;
}
