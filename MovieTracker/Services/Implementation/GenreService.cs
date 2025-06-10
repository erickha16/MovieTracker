using Microsoft.EntityFrameworkCore;
using MovieTracker.Constants;
using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Services.Implementation
{
    public class GenreService: IGenreService
    {
        //// ------ Inyección de dependencias del contexto de la base de datos -------
        //La inyección de dependencias permite que el servicio pueda acceder a la base de datos sin necesidad de crear una
        //instancia del contexto directamente.

        private readonly ApplicationDbContext _context;

        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }


        //------------------------------------------------------------------------

        //Implementación de los métodos definidos en IGenreService
        public async Task<List<GenreDTO>> GetAllAsync()
        {
            var gnres = await _context.Genres
                .Where(g => !g.IsDeleted)
                .Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Active = g.Active,
                    HighSystem = g.HighSystem
                })
                .ToListAsync();

            return gnres;
        }

        // Método para obtener un género por ID 
        public async Task<GenreDTO> GetByIdAsync(int id)
        {
            var genre = await _context.Genres
                .Where(g => g.Id == id && !g.IsDeleted)
                .Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Active = g.Active,
                    HighSystem = g.HighSystem
                })
                .FirstOrDefaultAsync();
            if (genre == null)
            {
                throw new ApplicationException(Messages.Error.GenreNotFound);
            }
            return genre;
        }

        // Método para agregar un nuevo género
        public async Task AddAsync(GenreDTO genreDTO)
        {
            var genre = new Models.Genre
            {
                Name = genreDTO.Name,
                Active = true, // Por defecto, al crear un género, lo marcamos como activo
                HighSystem = genreDTO.HighSystem
            };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        // Métodos para actualizar
        public async Task UpdateAsync(GenreDTO genreDTO)
        {
           var genre = await _context.Genres.FindAsync(genreDTO.Id);
            if (genre == null)
            {
                throw new ApplicationException(Messages.Error.GenreNotFound);
            }
            genre.Name = genreDTO.Name;

            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

        // Método para eliminar un género por ID (Cambiaremos IsDeleted a true)
        public async Task DeleteAsync(int id)
        {
           var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                throw new ApplicationException(Messages.Error.GenreNotFound);
            }
            genre.IsDeleted = true; // Cambiamos IsDeleted a true para simular una eliminación lógica
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }



    }
}
