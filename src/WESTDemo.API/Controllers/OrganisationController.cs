using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.API.Controllers;
using WESTDemo.Domain.Models;

namespace src.WESTDemo.API.Controllers
{
    public class OrganisationController : MainController
    {
        private readonly IOrganisationService _orgServices;
        private readonly IMapper _mapper;
        public OrganisationController(IMapper mapper, IOrganisationService orgServices)
        {
            _mapper = mapper;
            _orgServices = orgServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orgs = await _orgServices.GetAll();
            return Ok(_mapper.Map<IEnumerable<OrganisationResultDto>>(orgs));
        }

         [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var org = await _orgServices.GetById(id);

            if (org == null) return NotFound();

            return Ok(_mapper.Map<OrganisationResultDto>(org));

        }

        [HttpPost]
        public async Task<IActionResult> Add(OrganisationAddDto newOrg)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var org = _mapper.Map<Organisation>(newOrg);
            var orgResult = await _orgServices.Add(org);

            if (orgResult == null) return BadRequest();

            return Ok(_mapper.Map<OrganisationResultDto>(orgResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, OrganisationEditDto updatedOrg)
        {
            if (id != updatedOrg.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var orgResult = await _orgServices.Update(_mapper.Map<Organisation>(updatedOrg));
            if (orgResult == null) return BadRequest();

            return Ok(_mapper.Map<OrganisationResultDto>(orgResult));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var org = await _orgServices.GetById(id);

            if (org == null) return NotFound();
            
            if (!await _orgServices.Remove(org))
                return BadRequest();
                
            return Ok();
        }

        [HttpGet("search/{orgName}")]
        public async Task<IActionResult> Search(string orgName)
        {
            var orgs = _mapper.Map<List<Organisation>>(await _orgServices.Search(orgName));

            if (orgs == null || orgs.Count == 0) return NotFound("No organisation found");

            return Ok(_mapper.Map<IEnumerable<OrganisationResultDto>>(orgs));

        } 

    }
}