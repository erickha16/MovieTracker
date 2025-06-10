using Microsoft.EntityFrameworkCore;
using MovieTracker.Constants;
using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Models;
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
            var movie = await _context.Movies
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
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                throw new ApplicationException(Messages.Error.MovieNotFound);
            }

            return movie;
        }

        //Agregar una nueva película--------------------------------------------------------------------------------------------------------------
        public async Task AddAsync(MovieDTO movieDTO)
        {
            //Cargar la imagen en el servidor y obtener la URL
            var urlImagen = await _imageService.UploadImage(movieDTO.File); // Llama al servicio de imágenes para cargar la imagen y obtener la URL

            //Crear una nueva instancia de Movie y mapear los datos desde MovieDTO
            var movie = new Movie
            {
                Title = movieDTO.Title,
                Year = movieDTO.Year,
                Director = movieDTO.Director,
                Description = movieDTO.Description,
                PosterUrl = urlImagen, // Asignar la URL de la imagen cargada
                GenderId = movieDTO.GenreId,
                PlataformId = movieDTO.PlatformId,
                Active = true, // Por defecto, al agregar una nueva película, se establece como activa
            };

            //Agregar la nueva película al contexto de la base de datos
            await _context.Movies.AddAsync(movie); // Agrega la película al contexto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        }

        //Actualizar una película existente--------------------------------------------------------------------------------------------------------------
        public async Task UpdateAsync(MovieDTO movieDTO)
        {
            var movie = await _context.Movies.FindAsync(movieDTO.Id); // Busca la película por ID
            if (movie == null )
            {
                throw new ApplicationException(Messages.Error.MovieNotFound); // Si no se encuentra, lanza una excepción
            }
            //Cargar la imagen en el servidor y obtener la URL
            var urlImagen = await _imageService.UploadImage(movieDTO.File); // Llama al servicio de imágenes para cargar la imagen y obtener la URL


            //Actualiza las propiedades del producto con los valores del DTO (Los campos que reremos reemplazar)
            movie.Title = movieDTO.Title;
            movie.Year = movieDTO.Year;
            movie.Director = movieDTO.Director;
            movie.Description = movieDTO.Description;
            //Si no hay una imagen cargada, se mantiene la URL existente
            movie.PosterUrl = string.IsNullOrEmpty(movieDTO.File?.FileName) ? movie.PosterUrl : urlImagen; // Asigna la URL de la imagen cargada o mantiene la existente si no hay nueva imagen
            movie.GenderId = movieDTO.GenreId;
            movie.PlataformId = movieDTO.PlatformId;

            //Guardar los cambios en la base de datos
            _context.Movies.Update(movie); // Actualiza la película en el contexto
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }

        //Eliminar una película por ID--------------------------------------------------------------------------------------------------------------
        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
