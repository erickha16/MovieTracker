using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Services.Implementation
{
    public class MovieService : IMovieService
    {
        // ------ Inyección de dependencias del contexto de la base de datos -------
        //La inyección de dependencias permite que el servicio pueda acceder a la base de datos sin necesidad de crear una
        //instancia del contexto directamente y también la instancia para cargar imágenes.
        private readonly ApplicationDbContext _context; //Contexto de la base de datos
        private readonly IImageService _imageService; //Servicio para manejar imágenes
        public MovieService(ApplicationDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }
        //------------------------------------------------------------------------

        //Implementación de los métodos definidos en IMovieService

        //Listar todas las películas--------------------------------------------------------------------------------------------------------------
        public async Task<List<MovieDTO>> GetAllAsync()
        {
            var movies = await _context.Movies
                .Where(m => !m.IsDeleted) // Filtrar películas activas
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Director = m.Director,
                    Description = m.Description,
                    PosterUrl = m.PosterUrl,
                    GenreId = m.GenderId,
                    Genre = m.Gender.Name,
                    PlatformId = m.PlataformId,
                    Platform = m.Plataform.Name
                })
                .ToListAsync();

            return movies;
        }

        //Obtener una película por ID--------------------------------------------------------------------------------------------------------------
        public async Task<MovieDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Agregar una nueva película--------------------------------------------------------------------------------------------------------------
        public async Task AddAsync(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        //Actualizar una película existente--------------------------------------------------------------------------------------------------------------
        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Eliminar una película por ID--------------------------------------------------------------------------------------------------------------
        public async Task UpdateAsync(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }
        
    }
}
