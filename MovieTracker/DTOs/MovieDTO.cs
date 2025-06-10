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



        [Display(Name = "Género")] //Para cuando se selccione en el formulario
        [Required(ErrorMessage = "Debes seleccionar un Género")]
        public int GenreId { get; set; }

        [Display(Name = "Género")] //Para mostrar en la vista
        public string? Genre { get; set; }


        [Display(Name = "Plataforma")] //Para cuando se selccione en el formulario
        public int? PlatformId { get; set; }

        [Display(Name = "Plataforma")] //Para mostrar en la vista
        public string? Platform { get; set; }

        [Display(Name = "Calificación")] //Para cuando se selccione en el formulario
        public int? RatingId { get; set; }

        [Display(Name = "Calificación")] //Para mostrar en la vista
        public string? Rating { get; set; } //Para mostrar en la vista
    }
}
