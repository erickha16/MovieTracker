using Microsoft.EntityFrameworkCore;
using MovieTracker.Models;

namespace MovieTracker.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        //Definir los modelos para que se creen en la base de datos
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorsMovies> ActorsMovies { get; set; }
        public DbSet<ActorsSeries> ActorsSeries { get; set; }
        public DbSet<Rating> Ratings { get; set; }


    }
}
