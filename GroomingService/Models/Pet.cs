using System.ComponentModel.DataAnnotations;

namespace GroomingService.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }
        public string AnimalType { get; set; }
        public string Breed { get; set; }
    }
}
