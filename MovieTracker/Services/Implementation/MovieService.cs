using Microsoft.EntityFrameworkCore;
using MovieTracker.Constants;
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

            /*
              var product = await _context.Products //Obtiene el producto por Id de la base de datos (Se requeire el contesxto)                
                .Select(p => new ProductDTO //Proyección a ProductDTO (es lo que pide la función) para devolver solo los datos necesarios
                {
                    Id = p.Id, //Id del producto
                    Name = p.Name, //Nombre del producto
                    Price = p.Price, //Precio del producto
                    Description = p.Description, //Descripción del producto
                    CategoryId = p.CategoryId, //Id de la categoría del producto
                    BrandId = p.BrandId, //Id de la marca del producto
                    HighSystem = p.HighSystem, //Indica si el producto es de alto sistema
                    Active = p.Active, //Estado activo del producto
                    IsDeleted = p.IsDeleted, //Indica si el producto está eliminado
                    // Aquí se pueden agregar más propiedades del DTO según sea necesario
                    Category = p.Category.Name, //Nombre de la categoría del producto (asumiendo que Category es una propiedad de navegación)
                    Brand = p.Brand.Name //Nombre de la marca del producto (asumiendo que Brand es una propiedad de navegación)

                })
                .FirstOrDefaultAsync(p => p.Id == id); //Obtiene el primer resultado que cumple el la condición o null si no existe

             */

            if (movie == null)
            {
                throw new ApplicationException(Messages.Error.MovieNotFound);
            }

            return movie;
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
