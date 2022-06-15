using System.ComponentModel.DataAnnotations;

namespace GroomingService.Dtos
{
    public class CaseCreateDto
    {
        [Required]
        public int PetId { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}