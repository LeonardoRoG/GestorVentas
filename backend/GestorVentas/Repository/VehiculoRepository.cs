using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;

namespace GestorVentas.Repository;

public interface IVehiculoRepository
{
    List<VehiculoDto> GetAllVehiculos();
    VehiculoDto GetVehiculo(int idVehiculo);
    void AddVehiculo(VehiculoDto vehiculoDto);
    void RemoveVehiculo(int idVehiculo);
    void UpdateVehiculo(int idVehiculo, VehiculoDto vehiculoDto);
}

public class VehiculoRepository(AppDbContext context) : IVehiculoRepository
{
    public void AddVehiculo(VehiculoDto vehiculoDto)
    {
        Vehiculo vehiculoNuevo = new()
        {
            Nombre = vehiculoDto.Nombre,
            Matricula = vehiculoDto.Matricula,
            Marca = vehiculoDto.Marca,
            Modelo = vehiculoDto.Modelo,
            Tipo = vehiculoDto.Tipo,
            Año = vehiculoDto.Año,
            Combustible = vehiculoDto.Combustible,
            Litros = vehiculoDto.Litros
        };
        context.Add(vehiculoNuevo);
        context.SaveChanges();
    }

    public List<VehiculoDto> GetAllVehiculos()
    {
        var vehiculos = context.Vehiculos.ToList();
        return vehiculos.Adapt<List<VehiculoDto>>();
    }

    public VehiculoDto GetVehiculo(int idVehiculo)
    {
        var vehiculo = context.Vehiculos.FirstOrDefault(x => x.IdVehiculo == idVehiculo);
        return vehiculo.Adapt<VehiculoDto>();
    }

    public void RemoveVehiculo(int idVehiculo)
    {
        var vehiculo = context.Vehiculos.FirstOrDefault(x => x.IdVehiculo == idVehiculo);
        if (vehiculo == null)
            throw new Exception($"El vehiculo con id {idVehiculo} no existe.");

        context.Vehiculos.Remove(vehiculo);
        context.SaveChanges();
    }

    public void UpdateVehiculo(int idVehiculo, VehiculoDto vehiculoDto)
    {
        var vehiculo = context.Vehiculos.FirstOrDefault(x => x.IdVehiculo == idVehiculo);
        if (vehiculo == null) throw new Exception($"El vehiculo con id {idVehiculo} no existe");

        vehiculo.Nombre = vehiculoDto.Nombre;
        vehiculo.Matricula = vehiculoDto.Matricula;
        vehiculo.Marca = vehiculoDto.Marca;
        vehiculo.Modelo = vehiculoDto.Modelo;
        vehiculo.Tipo = vehiculoDto.Tipo;
        vehiculo.Año = vehiculoDto.Año;
        vehiculo.Combustible = vehiculoDto.Combustible;
        vehiculo.Litros = vehiculoDto.Litros;

        context.SaveChanges();
    }
}
