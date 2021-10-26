using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GroomingService.Models;
using System.Collections.Generic;
using GroomingService.Data;
using GroomingService.Dtos;

namespace GroomingService.Controllers
{
    //api/cases can just put hard name in instead of [controller]
    [Route("api/cases")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICaseRepo _repository;
        private readonly IMapper _mapper;
        public CasesController(ICaseRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CaseReadDto>> GetAllCases()
        {
            var cases = _repository.GetAllCases();

            return Ok(_mapper.Map<IEnumerable<CaseReadDto>>(cases));
        }

        [HttpGet("{id}", Name="GetCaseById")]
        public ActionResult <CaseReadDto> GetCaseById(int id)
        {
            var caseItem = _repository.GetCaseById(id);
            if(caseItem != null)
            {
                return Ok(_mapper.Map<CaseReadDto>(caseItem));
            }
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult <CaseReadDto> CreateCase(CaseCreateDto caseCreateDto)
        {
            //mapping the case data coming in to the case model using auto mapper.
            var caseModel = _mapper.Map<Case>(caseCreateDto);
            _repository.CreateCase(caseModel);
            _repository.SaveChanges();

            var CaseReadDto = _mapper.Map<CaseReadDto>(caseModel);
            
            //creates 201 created route  grab url for header, grab ID to know what id needs to be addded to url then add the data.
            return CreatedAtRoute(nameof(GetCaseById), new {Id = CaseReadDto.Id}, CaseReadDto);
        }
    }
}