using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Cliente")]
public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(50)]
    public required string Nombre { get; set; }

    public int? DNI {  get; set; }

    public int? CUIT {  get; set; }

    public string? Direccion {  get; set; }

    public string? Ciudad {  get; set; }

    public int Telefono { get; set; }

    [StringLength(30)]
    public required string CondicionIVA { get; set; }

    public List<Orden> Ordenes { get; set; } = [];
}
