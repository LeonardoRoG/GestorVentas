using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas.Repository;

public interface IVehiculoRepository
{
    Task<List<VehiculoDto>> GetAllVehiculos();
    Task<VehiculoDto> GetVehiculo(int idVehiculo);
    void AddVehiculo(VehiculoDto vehiculoDto);
    void RemoveVehiculo(int idVehiculo);
    void UpdateVehiculo(int idVehiculo, VehiculoDto vehiculoDto);
}

public class VehiculoRepository(AppDbContext context) : IVehiculoRepository
{
    public async void AddVehiculo(VehiculoDto vehiculoDto)
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
        await context.SaveChangesAsync();
    }

    public async Task<List<VehiculoDto>> GetAllVehiculos()
    {
        var vehiculos = await context.Vehiculos.ToListAsync();
        return vehiculos.Adapt<List<VehiculoDto>>();
    }

    public async Task<VehiculoDto> GetVehiculo(int idVehiculo)
    {
        var vehiculo = await context.Vehiculos.FirstOrDefaultAsync(x => x.IdVehiculo == idVehiculo);
        return vehiculo.Adapt<VehiculoDto>();
    }

    public async void RemoveVehiculo(int idVehiculo)
    {
        var vehiculo = await context.Vehiculos.FirstOrDefaultAsync(x => x.IdVehiculo == idVehiculo);
        if (vehiculo == null)
            throw new Exception($"El vehiculo con id {idVehiculo} no existe.");

        context.Vehiculos.Remove(vehiculo);
        await context.SaveChangesAsync();
    }

    public async void UpdateVehiculo(int idVehiculo, VehiculoDto vehiculoDto)
    {
        var vehiculo = await context.Vehiculos.FirstOrDefaultAsync(x => x.IdVehiculo == idVehiculo);
        if (vehiculo == null) throw new Exception($"El vehiculo con id {idVehiculo} no existe");

        vehiculo.Nombre = vehiculoDto.Nombre;
        vehiculo.Matricula = vehiculoDto.Matricula;
        vehiculo.Marca = vehiculoDto.Marca;
        vehiculo.Modelo = vehiculoDto.Modelo;
        vehiculo.Tipo = vehiculoDto.Tipo;
        vehiculo.Año = vehiculoDto.Año;
        vehiculo.Combustible = vehiculoDto.Combustible;
        vehiculo.Litros = vehiculoDto.Litros;

        await context.SaveChangesAsync();
    }
}
