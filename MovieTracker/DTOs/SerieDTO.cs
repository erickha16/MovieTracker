using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class SerieDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Description { get; set; }
        public int Seasons { get; set; }
        public int Episodes { get; set; }

        public string? PosterUrl { get; set; }

        [Required]
        public int GenreId { get; set; }


        public int? PlatformId { get; set; }

        public int? RatingId { get; set; }
    }
}
