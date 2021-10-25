using System.Collections.Generic;
using System.Linq;
using GroomingService.Models;

namespace GroomingService.Data
{
    public class sqlCaseRepo : ICaseRepo
    {
        private readonly GroomingContext _context;
        public sqlCaseRepo(GroomingContext context)
        {
            _context = context;
        }
        public IEnumerable<Case> GetAllCases()
        {
            return _context.Cases.ToList();
        }

        public Case GetCaseById(int id)
        {
            return _context.Cases.FirstOrDefault(c => c.Id == id);
        }
    }
}