using System.Collections.Generic;
using GroomingService.Models;

namespace GroomingService.Data
{
    public class MockCaseRepo : ICaseRepo
    {
        public IEnumerable<Case> GetAllCases()
        {
            var cases = new List<Case>
            {
                new Case{Id=0, PetId=1, OwnerId=1},
                new Case{Id=1, PetId=0, OwnerId=2},
                new Case{Id=2, PetId=2, OwnerId=0}
            };
            return cases;
        }

        public Case GetCaseById(int id)
        {
            return new Case{Id=0, PetId=1, OwnerId=2};
        }
    }
}