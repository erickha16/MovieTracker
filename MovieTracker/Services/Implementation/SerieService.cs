using Microsoft.EntityFrameworkCore;
using MovieTracker.Constants;
using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Models;
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
            var serie = await _context.Series
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
               .FirstOrDefaultAsync(s => s.Id == id);

            if (serie == null)
            {
                throw new ApplicationException(Messages.Error.SerieNotFound);
            }

            return serie;
        }

        //Agregar una nueva serie--------------------------------------------------------------------------------------------------------------
        public async Task AddAsync(SerieDTO serieDTO)
        {
            //Cargar la imagen en el servidor y obtener la URL
            var urlImagen = await _imageService.UploadImage(serieDTO.File); // Llama al servicio de imágenes para cargar la imagen y obtener la URL

            //Crear una nueva instancia de Serie y mapear los datos desde SerieDTO
            var serie = new Serie
            {
                Title = serieDTO.Title,
                Year = serieDTO.Year,
                Director = serieDTO.Director,
                Description = serieDTO.Description,
                Seasons = serieDTO.Seasons,
                Episodes = serieDTO.Episodes,
                PosterUrl = urlImagen, // Asignar la URL de la imagen cargada
                GenreId = serieDTO.GenreId,
                PlatformId = serieDTO.PlatformId,
                Active = true, // Por defecto, al agregar una nueva serie, se establece como activa
            };

            //Agregar la nueva serie al contexto de la base de datos
            await _context.Series.AddAsync(serie); // Agrega la serie al contexto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

       
        }

        //Actualizar una serie existente--------------------------------------------------------------------------------------------------------------
        public async Task UpdateAsync(SerieDTO serieDTO)
        {
            var serie = await _context.Series.FindAsync(serieDTO.Id);
            if (serie == null)
            {
                throw new ApplicationException(Messages.Error.SerieNotFound);
            }

            //Cargar la imagen en el servidor y obtener la URL
            var urlImagen = await _imageService.UploadImage(serieDTO.File); // Llama al servicio de imágenes para cargar la imagen y obtener la URL

            //Actualiza las propiedades del producto con los valores del DTO (Los campos que reremos reemplazar)
            serie.Title = serieDTO.Title;
            serie.Year = serieDTO.Year;
            serie.Director = serieDTO.Director;
            serie.Description = serieDTO.Description;
            serie.Seasons = serieDTO.Seasons;
            serie.Episodes = serieDTO.Episodes;
            //Si no hay una imagen cargada, se mantiene la URL existente
            serie.PosterUrl = string.IsNullOrEmpty(serieDTO.File?.FileName) ? serie.PosterUrl : urlImagen; // Asignar la URL de la imagen cargada o mantener la existente
            serie.GenreId = serieDTO.GenreId;
            serie.PlatformId = serieDTO.PlatformId;

            //Guardar los cambios en la base de datos
            _context.Series.Update(serie); // Actualiza la serie en el contexto
            await _context.SaveChangesAsync();

        }

        //Eliminar una serie por ID--------------------------------------------------------------------------------------------------------------
        public async Task DeleteAsync(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                throw new ApplicationException(Messages.Error.SerieNotFound);
            }

            // Marcar la serie como eliminada en lugar de eliminarla físicamente
            serie.IsDeleted = true; // Cambia el estado de IsDeleted a true
            _context.Series.Update(serie); // Actualiza la serie en el contexto
            await _context.SaveChangesAsync();
        }

    }
}
