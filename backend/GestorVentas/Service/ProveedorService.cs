using GestorVentas.Domain;
using GestorVentas.Endpoints.DTO;
using GestorVentas.Repository;
using Mapster;

namespace GestorVentas.Service;

public interface IProveedorService
{
    void AddProveedor(ProveedorRequestDto proveedorDto);
    void RemoveProveedor(int idProveedor);
    void UpdateProveedor(int idProveedor, ProveedorRequestDto proveedor);
    List<ProveedorResponseDto> GetAllProveedors();
    ProveedorResponseDto GetProveedor(int idProveedor);
}

public class ProveedorService(IProveedorRepository proveedorRepository) : IProveedorService
{
    public void AddProveedor(ProveedorRequestDto proveedorDto)
    {
        proveedorRepository.AddProveedor(proveedorDto.Adapt<ProveedorDto>());
    }

    public List<ProveedorResponseDto> GetAllProveedors()
    {
        return proveedorRepository.GetAllProveedors().Adapt<List<ProveedorResponseDto>>();
    }

    public ProveedorResponseDto GetProveedor(int idProveedor)
    {
        return proveedorRepository.GetProveedor(idProveedor).Adapt<ProveedorResponseDto>();
    }

    public void RemoveProveedor(int idProveedor)
    {
        proveedorRepository.RemoveProveedor(idProveedor);
    }

    public void UpdateProveedor(int idProveedor, ProveedorRequestDto proveedorDto)
    {
        proveedorRepository.UpdateProveedor(idProveedor, proveedorDto.Adapt<ProveedorDto>());
    }
}
