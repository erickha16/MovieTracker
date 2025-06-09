using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class RegistryDTO
    {
        [Display(Name = "Estatus")] //Display name hace que se muestre lo inidcado en lugar de "active"
        public bool Active { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Fecha de creación")]//Display name hace que se muestre lo inidcado en lugar de "HighSystem"
        public DateTime HighSystem { get; set; } = DateTime.Now;
    }
}
