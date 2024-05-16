using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Orden")]
public class Orden
{
    [Key]
    public int IdOrden {  get; set; }

    public DateTime FechaOrden { get; set; }

    public string? Destino { get; set; }

    public required string MetodoEnvio { get; set; }

    [ForeignKey("IdCliente")]
    public required Cliente Cliente { get; set; }

    [ForeignKey("IdEmpleado")]
    public required Empleado Empleado { get; set; }

    public List<DetalleOrden> DetallesOrdenes { get; set; } = [];
}
