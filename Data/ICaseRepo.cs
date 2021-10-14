using System.Collections.Generic;
using GroomingService.Models;

namespace GroomingService.Data
{
    public interface ICaseRepo
    {
        IEnumerable<Case> GetAllCases();
        Case GetCaseById(string id);
        
    }
}