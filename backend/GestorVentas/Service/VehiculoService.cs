using GestorVentas.Endpoints.DTO;
using GestorVentas.Repository;
using Mapster;

namespace GestorVentas.Service;

public interface IVehiculoService
{
    List<VehiculoResponseDto> GetAllVehiculos();
    VehiculoResponseDto GetVehiculo(int idVehiculo);
    void AddVehiculo(VehiculoRequestDto vehiculoDto);
    void RemoveVehiculo(int idVehiculo);
    void UpdateVehiculo(int idVehiculo, VehiculoRequestDto vehiculoDto);
}

public class VehiculoService(IVehiculoRepository vehiculoRepository) : IVehiculoService
{
    public void AddVehiculo(VehiculoRequestDto vehiculoDto)
    {
        vehiculoRepository.AddVehiculo(vehiculoDto.Adapt<VehiculoDto>());
    }

    public List<VehiculoResponseDto> GetAllVehiculos()
    {
        return vehiculoRepository.GetAllVehiculos().Adapt<List<VehiculoResponseDto>>();
    }

    public VehiculoResponseDto GetVehiculo(int idVehiculo)
    {
        return vehiculoRepository.GetVehiculo(idVehiculo).Adapt<VehiculoResponseDto>();
    }

    public void RemoveVehiculo(int idVehiculo)
    {
        vehiculoRepository.RemoveVehiculo(idVehiculo);
    }

    public void UpdateVehiculo(int idVehiculo, VehiculoRequestDto vehiculoDto)
    {
        vehiculoRepository.UpdateVehiculo(idVehiculo, vehiculoDto.Adapt<VehiculoDto>());
    }
}
