using MovieTracker.DTOs;

namespace MovieTracker.Services.Interface
{
    public interface ISerieService
    {
        //-------------------  Métodos para manejar series -------------------

           // Obtiene una lista de todas las series
            Task<List<SerieDTO>> GetAllAsync();
    
            // Obtener una serie por ID
            Task<SerieDTO> GetByIdAsync(int id);
    
            // Agregar una nueva serie
            Task AddAsync(SerieDTO serieDTO);
    
            // Actualizar una serie existente
            Task UpdateAsync(SerieDTO serieDTO);
    
            // Eliminar una serie por ID
            Task DeleteAsync(int id);
    }
}
