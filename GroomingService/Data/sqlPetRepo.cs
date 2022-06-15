using GroomingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingService.Data
{
    public class sqlPetRepo : IPetRepo
    {
        private readonly GroomingContext _context;
        public sqlPetRepo(GroomingContext context)
        {
            _context = context;
        }
        public void CreatePet(Pet petData)
        {
            if (petData == null)
            {
                throw new ArgumentNullException(nameof(petData));
            }

            _context.Pets.Add(petData);
        }

        public void DeletePet(Pet petData)
        {
            if (petData == null)
            {
                throw new ArgumentNullException(nameof(petData));
            }
            _context.Pets.Remove(petData);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pet GetPetById(int id)
        {
            return _context.Pets.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePet(Pet petData)
        {
            //nothing
        }
    }
}
