namespace GestorVentas.Endpoints.DTO;

public class ProveedorDto
{
    public int IdProveedor {  get; set; }
    public required string Nombre { get; set; }
    public required int CUIT {  get; set; }
    public required string Direccion { get; set; }
    public required string Ciudad {  get; set; }
    public int Telefono { get; set; }
}

public class ProveedorRequestDto
{
    public required string Nombre { get; set; }
    public required int CUIT {  get; set; }
    public required string Direccion { get; set; }
    public required string Ciudad {  get; set; }
    public int Telefono { get; set; }
}

public class ProveedorResponseDto
{
    public int IdProveedor {  get; set; }
    public required string Nombre { get; set; }
    public required int CUIT {  get; set; }
    public required string Direccion { get; set; }
    public required string Ciudad {  get; set; }
    public int Telefono { get; set; }
}
