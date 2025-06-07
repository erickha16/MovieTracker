using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Genre: Registry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Propiedades de navegación
        public IEnumerable<Movie>? Movies { get; set; }
        public IEnumerable<Serie>? Series { get; set; }
    }
}
