using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Services.Implementation
{
    public class SerieService : ISerieService
    {
        // ------ Inyección de dependencias del contexto de la base de datos -------
        //La inyección de dependencias permite que el servicio pueda acceder a la base de datos sin necesidad de crear una
        //instancia del contexto directamente.
        private readonly ApplicationDbContext _context; //Contexto de la base de datos
        public SerieService(ApplicationDbContext context)
        {
            _context = context;
        }

        //------------------------------------------------------------------------

        //Implementación de los métodos definidos en ISerieService

        //Listar todas las series--------------------------------------------------------------------------------------------------------------
        public Task<List<SerieDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //Obtener una serie por ID--------------------------------------------------------------------------------------------------------------
        public Task<SerieDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Agregar una nueva serie--------------------------------------------------------------------------------------------------------------
        public Task AddAsync(SerieDTO serieDTO)
        {
            throw new NotImplementedException();
        }

        //Actualizar una serie existente--------------------------------------------------------------------------------------------------------------
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Eliminar una serie por ID--------------------------------------------------------------------------------------------------------------
        public Task UpdateAsync(SerieDTO serieDTO)
        {
            throw new NotImplementedException();
        }
       
    }
}
