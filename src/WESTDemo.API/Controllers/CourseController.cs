using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WESTDemo.API.Dto.CourseDto;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Controllers
{
    public class CourseController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        public CourseController(IMapper mapper, ICourseService courseService)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CourseResultDto>>(courses));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetById(id);
            if (course == null) return NotFound("Course not found");

            return Ok(_mapper.Map<CourseResultDto>(course));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseAddDto newCourse)
        {
            if (!ModelState.IsValid) return BadRequest();
            var courseResult = await _courseService.Add(_mapper.Map<Course>(newCourse));
            if (courseResult == null) return BadRequest();

            return Ok(_mapper.Map<CourseResultDto>(courseResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CourseEditDto updatedCourse)
        {
            if (id != updatedCourse.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var courseResult = await _courseService.Update(_mapper.Map<Course>(updatedCourse));
            if (courseResult == null) return BadRequest();

            return Ok(_mapper.Map<CourseResultDto>(courseResult));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var course = await _courseService.GetById(id);

            if (course == null) return NotFound();

            if (!await _courseService.Remove(course))
                return BadRequest();

            return Ok();

        }

        [HttpGet("search/{courseName}")]
        public async Task<IActionResult> Search(string courseName)
        {
            var courses = _mapper.Map<List<Course>>(await _courseService.Search(courseName));

            if (courses == null || courses.Count == 0) return NotFound("No course found");

            return Ok(_mapper.Map<IEnumerable<CourseResultDto>>(courses));

        }


    }
}