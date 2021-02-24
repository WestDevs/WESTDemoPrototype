using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WESTDemo.API.Dto.CentreDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Controllers
{
    public class CentreController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICentreService _centreService;
        public CentreController(IMapper mapper, ICentreService centreService)
        {
            _centreService = centreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var centres = await _centreService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CentreResultDto>>(centres));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var centre = await _centreService.GetById(id);
            if (centre ==null) return NotFound("Centre not found.");

            return Ok(_mapper.Map<CentreResultDto>(centre));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CentreAddDto newCentre)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var centre = _mapper.Map<Centre>(newCentre);
            
            var centreResult = await _centreService.Add(centre);

            if (centreResult == null) return BadRequest();

            return Ok(_mapper.Map<CentreResultDto>(centreResult));
        }

    }
}