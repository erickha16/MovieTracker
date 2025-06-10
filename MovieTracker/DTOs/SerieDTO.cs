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
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Year { get; set; }

        public string? Director { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Display(Name = "Temporadas")]
        [Required(ErrorMessage = "Indique el número de temporadas")]
        public int Seasons { get; set; }

        [Display(Name = "Episodios")]
        [Required(ErrorMessage = "La serie debe contener al menos 1 episodio")]
        public int Episodes { get; set; }

        public string? PosterUrl { get; set; }

        public IFormFile? File { get; set; } // Para recibir el archivo de imagen



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
