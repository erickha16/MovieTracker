using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class MovieDTO
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
    }
}
