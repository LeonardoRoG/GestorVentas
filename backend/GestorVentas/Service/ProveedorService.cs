using GestorVentas.Domain;

namespace GestorVentas.Service;

public interface IProveedorService
{
    void AddProveedor(Proveedor proveedor);
    void RemoveProveedor(int idProveedor);
    void UpdateProveedor(int idProveedor, Proveedor proveedor);
    List<Proveedor> GetAllProveedors();
    Proveedor GetProveedor(int idProveedor);
}

public class ProveedorService
{
}
