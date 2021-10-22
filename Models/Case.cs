using System.ComponentModel.DataAnnotations;

namespace GroomingService.Models
{
    public class Case
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PetId { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}