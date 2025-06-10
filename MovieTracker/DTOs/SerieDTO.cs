using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class SerieDTO: RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "La película debe de tener un título")]
        public string Title { get; set; }

        [Display(Name = "Año de estreno")]
        public int Year { get; set; }

        public string? Director { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Display(Name = "Temporadas")]
        public int Seasons { get; set; }

        [Display(Name = "Episodios")]
        public int Episodes { get; set; }

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
