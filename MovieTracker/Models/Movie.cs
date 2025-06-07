using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Movie:Registry
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Description { get; set; }

        public string? PosterUrl { get; set; }

        [Required]
        public int GenderId { get; set; }

        public int PlataformId { get; set; }

        public int RatingId { get; set; } //Duda si esto va aquí

        //Propeidades de navegación
        public IEnumerable<ActorsMovies>? Actorsmovies { get; set; } // Relación con actores
        public Genre Gender { get; set; }

        public Platform? Plataform { get; set; }

        public Rating? Rating { get; set; } // O va aquí

    }
}
