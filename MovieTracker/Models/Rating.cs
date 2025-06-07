using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Rating:Registry
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Score { get; set; }  // Calificación numérica del 1 al 10

        [StringLength(500)]
        public string? Comment { get; set; }  // Comentario opcional

        // Relaciones 1 a 1
        //public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        //public int? SeriesId { get; set; }
        public Serie? Serie { get; set; }
    }
}
