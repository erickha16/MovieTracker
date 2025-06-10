using MovieTracker.DTOs;

namespace MovieTracker.Services.Interface
{
    public interface IPlatformService
    {
        //Mostrar todas las plataformas disponibles
        Task<List<PlatformDTO>> GetAllAsync();

        //Buscar una plataforma por su ID
        Task<PlatformDTO> GetByIdAsync(int id);

        //Crear una nueva plataforma
        Task<PlatformDTO> CreateAsync(PlatformDTO platformDto);

        //Actualizar una plataforma existente
        Task<PlatformDTO> UpdateAsync(int id, PlatformDTO platformDto);

        //Eliminar una plataforma por su ID
        Task DeleteAsync(int id);
    }
}
