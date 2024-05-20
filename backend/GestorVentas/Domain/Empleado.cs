using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Empleado")]
public class Empleado
{
    [Key]
    public int IdEmpleado { get; set; }

    [StringLength(50)]
    public required string Nombre { get; set; }

    public required int DNI {  get; set; }

    [StringLength(50)]
    public required string Direccion { get; set; }

    [StringLength(50)]
    public required string Ciudad {  get; set; }

    public required int Telefono { get; set; }

    public DateTime FechaContratacion { get; set; }

    [StringLength(50)]
    public required string Puesto { get; set; }

    public required decimal Sueldo { get; set; }

    [ForeignKey("Jefe")]
    public int? IdJefe {  get; set; }

    public Empleado? Jefe { get; set; }

    public List<Empleado>? Subordinados { get; set; } = [];

    [ForeignKey("IdVehiculo")]
    public Vehiculo? Vehiculo { get; set; }

    public List<Orden> Ordenes { get; set; } = [];
}
