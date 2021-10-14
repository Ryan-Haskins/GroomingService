using Microsoft.AspNetCore.Mvc;
using GroomingService.Models;
using System.Collections.Generic;
using GroomingService.Data;

namespace GroomingService.Controllers
{
    //api/cases can just put hard name in instead of [controller]
    [Route("api/cases")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly MockCaseRepo _repository = new MockCaseRepo();

        [HttpGet]
        public ActionResult <IEnumerable<Case>> GetAllCases()
        {
            var cases = _repository.GetAllCases();

            return Ok(cases);
        }

        [HttpGet("{id}")]
        public ActionResult <Case> GetCaseById(string id)
        {
            var caseItem = _repository.GetCaseById(id);

            return Ok(caseItem);
        }
    }
}