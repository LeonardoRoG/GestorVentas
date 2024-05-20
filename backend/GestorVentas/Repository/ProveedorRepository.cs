using GestorVentas.Database;
using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using Mapster;

namespace GestorVentas.Repository;

public interface IProveedorRepository
{
    void AddProveedor(ProveedorDto proveedorDto);
    void RemoveProveedor(int idProveedor);
    void UpdateProveedor(int idProveedor, ProveedorDto proveedorDto);
    List<ProveedorDto> GetAllProveedors();
    ProveedorDto GetProveedor(int idProveedor);
}

public class ProveedorRepository(AppDbContext context) : IProveedorRepository
{
    public void AddProveedor(ProveedorDto proveedorDto)
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
        context.SaveChanges();
    }

    public List<ProveedorDto> GetAllProveedors()
    {
        var proveedores = context.Proveedores.ToList();
        return proveedores.Adapt<List<ProveedorDto>>();
    }

    public ProveedorDto GetProveedor(int idProveedor)
    {
        var proveedor = context.Proveedores.Where(x => x.IdProveedor == idProveedor).SingleOrDefault();
        return proveedor.Adapt<ProveedorDto>();
    }

    public void RemoveProveedor(int idProveedor)
    {
        var proveedor = context.Proveedores.FirstOrDefault(x => x.IdProveedor == idProveedor);
        if (proveedor == null)
            throw new Exception($"El proveedor con id {idProveedor} no existe.");

        context.Proveedores.Remove(proveedor);
        context.SaveChanges();
    }

    public void UpdateProveedor(int idProveedor, ProveedorDto proveedorDto)
    {
        var proveedor = context.Proveedores.SingleOrDefault(x => x.IdProveedor == idProveedor);
        if (proveedor == null)
            throw new Exception($"El proveedor con id {idProveedor} no existe.");

        proveedor.Nombre = proveedorDto.Nombre;
        proveedor.CUIT = proveedorDto.CUIT;
        proveedor.Ciudad = proveedorDto.Ciudad;
        proveedor.Direccion = proveedorDto.Direccion;
        proveedor.Telefono = proveedorDto.Telefono;

        context.SaveChanges();
    }
}
