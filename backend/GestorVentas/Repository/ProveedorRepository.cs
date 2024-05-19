using GestorVentas.Domain;

namespace GestorVentas.Repository;

public interface IProveedorRepository
{
    void AddProveedor(Proveedor proveedor);
    void RemoveProveedor(int idProveedor);
    void UpdateProveedor(int idProveedor, Proveedor proveedor);
    List<Proveedor> GetAllProveedors();
    Proveedor GetProveedor(int idProveedor);
}

public class ProveedorRepository
{

}
