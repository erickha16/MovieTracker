using System.ComponentModel.DataAnnotations;

namespace MovieTracker.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
