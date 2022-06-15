using GroomingService.Models;
using System.Collections.Generic;

namespace GroomingService.Data
{
    public interface IPetRepo
    {
        bool SaveChanges();
        IEnumerable<Pet> GetAllPets();
        Pet GetPetById(int id);
        void CreatePet(Pet petData);
        void UpdatePet(Pet petData);
        void DeletePet(Pet petData);
    }
}
