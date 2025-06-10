using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(GenreDTO genreDTO)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(GenreDTO genreDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



    }
}
