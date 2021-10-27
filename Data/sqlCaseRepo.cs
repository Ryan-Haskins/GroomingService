using System.Collections.Generic;
using System.Linq;
using GroomingService.Models;
using System;


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

        public void CreateCase(Case caseData)
        {
            if (caseData == null) 
            {
                throw new ArgumentNullException(nameof(caseData));
            }

            _context.Cases.Add(caseData);
        }

        public void UpdateCase(Case caseData)
        {
           //nothing
        }

        public void DeleteCase(Case caseData)
        {
            if (caseData == null) 
            {
                throw new ArgumentNullException(nameof(caseData));
            }
            _context.Cases.Remove(caseData);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}