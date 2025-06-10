using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Services.Implementation
{
    public class PlatformService : IPlatformService
    {
        //Inyección de dependencias y constructor
        private readonly ApplicationDbContext _context;

        public PlatformService(ApplicationDbContext context)
        {
            _context = context;
        }


        // --------------------- Aquí se implementarán los métodos de la interfaz IPlatformService ---------------------
        // Mostrar todas las plataformas disponibles
        public Task<List<PlatformDTO>> GetAllAsync()
        {
           var platforms = _context.Platforms
                .Where(p => !p.IsDeleted) // Filtrar solo las plataformas activas
                .Select(p => new PlatformDTO
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
            return platforms;
        }

        // Buscar una plataforma por su ID
        public Task<PlatformDTO> GetByIdAsync(int id)
        {
            var platform = _context.Platforms
                .Where(p => p.Id == id)
                .Select(p => new PlatformDTO
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();
            return platform;
        }

        // Crear una nueva plataforma
        public Task<PlatformDTO> CreateAsync(PlatformDTO platformDto)
        {
            throw new NotImplementedException();
        }


        // Actualizar una plataforma existente
        public Task<PlatformDTO> UpdateAsync(int id, PlatformDTO platformDto)
        {
            throw new NotImplementedException();
        }


        // Eliminar una plataforma por su ID
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
