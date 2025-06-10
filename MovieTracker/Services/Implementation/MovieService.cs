using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Services.Implementation
{
    public class MovieService : IMovieService
    {
        // ------ Inyección de dependencias del contexto de la base de datos -------
        //La inyección de dependencias permite que el servicio pueda acceder a la base de datos sin necesidad de crear una
        //instancia del contexto directamente.
        private readonly ApplicationDbContext _context; //Contexto de la base de datos
        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }
        //------------------------------------------------------------------------

        //Implementación de los métodos definidos en IMovieService

        //Listar todas las películas--------------------------------------------------------------------------------------------------------------
        public Task<List<MovieDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //Obtener una película por ID--------------------------------------------------------------------------------------------------------------
        public Task<MovieDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Agregar una nueva película--------------------------------------------------------------------------------------------------------------
        public Task AddAsync(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        //Actualizar una película existente--------------------------------------------------------------------------------------------------------------
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Eliminar una película por ID--------------------------------------------------------------------------------------------------------------
        public Task UpdateAsync(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }
        
    }
}
