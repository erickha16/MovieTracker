using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class RaitingDTO: RegistryDTO
    {
        public int Id { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "La calificación es obligatoria.")]
        [Display(Name = "Calificación")] // Display name hace que se muestre lo indicado en lugar de "Score"
        public int Score { get; set; }  // Calificación numérica del 1 al 10

        [StringLength(500)]
        [Display(Name = "Comentario")]
        public string? Comment { get; set; }  // Comentario opcional
    }
}
