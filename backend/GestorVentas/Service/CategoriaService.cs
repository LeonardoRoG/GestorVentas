using GestorVentas.Endpoints.DTO;
using GestorVentas.Repository;
using Mapster;

namespace GestorVentas.Service;

public interface ICategoriaService
{
    List<CategoriaResponseDto> GetAllCategorias();
    CategoriaResponseDto GetCategoria(int idCategoria);
    void AddCategoria(CategoriaRequestDto categoriaDto);
    void RemoveCategoria(int idCategoria);
    void UpdateCategoria(int idCategoria, CategoriaRequestDto categoriaDto);
}

public class CategoriaService(ICategoriaRepository categoriaRepository) : ICategoriaService
{
    public void AddCategoria(CategoriaRequestDto categoriaDto)
    {
        categoriaRepository.AddCategoria(categoriaDto.Adapt<CategoriaDto>());
    }

    public List<CategoriaResponseDto> GetAllCategorias()
    {
        return categoriaRepository.GetAllCategorias().Adapt<List<CategoriaResponseDto>>();
    }

    public CategoriaResponseDto GetCategoria(int idCategoria)
    {
        return categoriaRepository.GetCategoria(idCategoria).Adapt<CategoriaResponseDto>();
    }

    public void RemoveCategoria(int idCategoria)
    {
        categoriaRepository.RemoveCategoria(idCategoria);
    }

    public void UpdateCategoria(int idCategoria, CategoriaRequestDto categoriaDto)
    {
        categoriaRepository.UpdateCategoria(idCategoria, categoriaDto.Adapt<CategoriaDto>());
    }
}
