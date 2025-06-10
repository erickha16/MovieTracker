using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Services.Implementation
{
    public class SerieService : ISerieService
    {
        // ------ Inyección de dependencias del contexto de la base de datos -------
        //La inyección de dependencias permite que el servicio pueda acceder a la base de datos sin necesidad de crear una
        //instancia del contexto directamente y también la instancia para cargar imágenes.

        private readonly ApplicationDbContext _context; //Contexto de la base de datos
        private readonly IImageService _imageService; //Servicio para manejar imágenes

        public SerieService(ApplicationDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        //------------------------------------------------------------------------

        //Implementación de los métodos definidos en ISerieService

        //Listar todas las series--------------------------------------------------------------------------------------------------------------
        public async Task<List<SerieDTO>> GetAllAsync()
        {
           var series = await _context.Series
                .Where(s => !s.IsDeleted) // Filtrar series activas
                .Select(s => new SerieDTO
                {
                    Id = s.Id,
                    Title = s.Title,
                    Year = s.Year,
                    Director = s.Director,
                    Description = s.Description,
                    Seasons = s.Seasons,
                    Episodes = s.Episodes,
                    PosterUrl = s.PosterUrl,
                    GenreId = s.GenreId,
                    Genre = s.Genre.Name,
                    PlatformId = s.PlatformId,
                    Platform = s.Platform.Name
                })
                .ToListAsync();
            return series;
        }

        //Obtener una serie por ID--------------------------------------------------------------------------------------------------------------
        public async Task<SerieDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Agregar una nueva serie--------------------------------------------------------------------------------------------------------------
        public async Task AddAsync(SerieDTO serieDTO)
        {
            throw new NotImplementedException();
        }

        //Actualizar una serie existente--------------------------------------------------------------------------------------------------------------
        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Eliminar una serie por ID--------------------------------------------------------------------------------------------------------------
        public async Task UpdateAsync(SerieDTO serieDTO)
        {
            throw new NotImplementedException();
        }
       
    }
}
