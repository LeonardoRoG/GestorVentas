using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorVentas.Domain;

[Table("Vehiculo")]
public class Vehiculo
{
    [Key]
    public int IdVehiculo {  get; set; }

    [StringLength(50)]
    public required string Marca { get; set; }

    [StringLength(50)]
    public required string Modelo { get; set; }

    public Tipo Tipo { get; set; }

    public int? Año { get; set; }

    public Combustible Combustible { get; set; }

    public int? Litros { get; set; }
}

public enum Combustible
{
    Nafta,
    Diesel,
    Electrico
}

public enum Tipo
{
    Auto,
    Camioneta,
    Furgon,
    Camion
}