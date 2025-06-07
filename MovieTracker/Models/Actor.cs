using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Actor: Registry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        //Propiedades de navegación
        public IEnumerable<ActorsMovies>? ActorsMovies { get; set; }
        public IEnumerable<ActorsSeries>? ActorsSeries { get; set; }

    }
}
