using System.Collections.Generic;
using GroomingService.Models;

namespace GroomingService.Data
{
    public interface ICaseRepo
    {
        bool SaveChanges();
        IEnumerable<Case> GetAllCases();
        Case GetCaseById(int id);
        void CreateCase(Case caseData);
        void UpdateCase(Case caseData);
        void DeleteCase(Case caseData);
    }
}