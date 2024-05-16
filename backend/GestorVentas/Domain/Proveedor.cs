using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Proveedor")]
public class Proveedor
{
    [Key]
    public int IdProveedor {  get; set; }

    [StringLength(50)]
    public required string Nombre { get; set; }

    public int CUIT {  get; set; }

    [StringLength(50)]
    public required string Direccion { get; set; }

    [StringLength(30)]
    public required string Ciudad {  get; set; }

    public int Telefono { get; set; }

    public List<Producto> Productos { get; set; } = [];
}
