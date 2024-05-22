using GestorVentas.Domain;

namespace GestorVentas.Endpoints.DTO;

public class VehiculoDto
{
    public int IdVehiculo { get; set; }
    public required string Nombre { get; set; }
    public required string Matricula { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public Tipo Tipo { get; set; }
    public int? Año { get; set; }
    public Combustible Combustible { get; set; }
    public int? Litros { get; set; }
}

public class VehiculoRequestDto
{
    public required string Nombre { get; set; }
    public required string Matricula { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public Tipo Tipo { get; set; }
    public int? Año { get; set; }
    public Combustible Combustible { get; set; }
    public int? Litros { get; set; }
}

public class VehiculoResponseDto
{
    public int IdVehiculo { get; set; }
    public required string Nombre { get; set; }
    public required string Matricula { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public Tipo Tipo { get; set; }
    public int? Año { get; set; }
    public Combustible Combustible { get; set; }
    public int? Litros { get; set; }
}
