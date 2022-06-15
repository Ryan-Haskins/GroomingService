using System.ComponentModel.DataAnnotations;


namespace GroomingService.Dtos
{
    public class PetCreateDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string AnimalType { get; set; }
        public string Breed { get; set; }
    }
}
