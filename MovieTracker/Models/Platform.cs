using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Platform: Registry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public IEnumerable<Movie>? Movies { get; set; }
        public IEnumerable<Serie>? Series { get; set; }
    }
}
