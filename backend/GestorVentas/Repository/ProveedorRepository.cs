using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas.Repository;

public interface IProveedorRepository
{
    void AddProveedor(ProveedorDto proveedorDto);
    void RemoveProveedor(int idProveedor);
    void UpdateProveedor(int idProveedor, ProveedorDto proveedorDto);
    Task<List<ProveedorDto>> GetAllProveedors();
    Task<ProveedorDto> GetProveedor(int idProveedor);
}

public class ProveedorRepository(AppDbContext context) : IProveedorRepository
{
    public async void AddProveedor(ProveedorDto proveedorDto)
    {
        try
        {
            Proveedor proveedorNuevo = new()
            {
                Nombre = proveedorDto.Nombre,
                CUIT = proveedorDto.CUIT,
                Direccion = proveedorDto.Direccion,
                Ciudad = proveedorDto.Ciudad,
                Telefono = proveedorDto.Telefono
            };

            context.Add(proveedorNuevo);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al agregar el proveedor.", ex);
        }
    }

    public async Task<List<ProveedorDto>> GetAllProveedors()
    {
        var proveedores = await context.Proveedores.ToListAsync();
        return proveedores.Adapt<List<ProveedorDto>>();
    }

    public async Task<ProveedorDto> GetProveedor(int idProveedor)
    {
        var proveedor = await context.Proveedores.Where(x => x.IdProveedor == idProveedor).SingleOrDefaultAsync();
        return proveedor.Adapt<ProveedorDto>();
    }

    public async void RemoveProveedor(int idProveedor)
    {
        try
        {
            var proveedor = await context.Proveedores.FirstOrDefaultAsync(x => x.IdProveedor == idProveedor) ?? throw new Exception($"El proveedor con id {idProveedor} no existe.");
            context.Proveedores.Remove(proveedor);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el proveedor", ex);
        }
    }

    public async void UpdateProveedor(int idProveedor, ProveedorDto proveedorDto)
    {
        try
        {
            var proveedor = context.Proveedores.SingleOrDefault(x => x.IdProveedor == idProveedor) ?? throw new Exception($"El proveedor con id {idProveedor} no existe.");
            proveedor.Nombre = proveedorDto.Nombre;
            proveedor.CUIT = proveedorDto.CUIT;
            proveedor.Ciudad = proveedorDto.Ciudad;
            proveedor.Direccion = proveedorDto.Direccion;
            proveedor.Telefono = proveedorDto.Telefono;

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el proveedor.", ex);
        }
    }
}
