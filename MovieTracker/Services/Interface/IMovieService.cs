using MovieTracker.DTOs;

namespace MovieTracker.Services.Interface
{
    public interface IMovieService
    {
        //-------------------  Métodos para manejar películas -------------------


        // Obtiene una lista de todas las películas
        Task<List<MovieDTO>> GetAllAsync();

        // Obtener una película por ID
        Task<MovieDTO> GetByIdAsync(int id);

        //Agregar una nueva película
        Task AddAsync (MovieDTO movieDTO);

        // Actualizar una película existente
        Task UpdateAsync(MovieDTO movieDTO);

        // Eliminar una película por ID
        Task DeleteAsync(int id);
    }
}
