using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class GenreDTO: RegistryDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")] // Mensaje de error personalizado si el campo es requerido en caso de que no se llene
        public string Name { get; set; }
    }
}
