using MovieTracker.DTOs;

namespace MovieTracker.Services.Interface
{
    public interface IGenreService
    {
        //Definir métodos que serán implementados en GenreService

        //Obtener todos los géneros
        Task<List<GenreDTO>> GetAllAsync();

        //Agregar un nuevo género
        Task AddAsync(GenreDTO genreDTO);

        //Actualizar un género existente
        Task UpdateAsync(GenreDTO genreDTO);

        //Eliminar un género por ID
        Task DeleteAsync(int id);
    }
}
