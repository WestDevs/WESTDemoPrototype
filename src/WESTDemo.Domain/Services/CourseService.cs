using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> Add(Course newCourse)
        {
            if (_courseRepository
                    .Search(c => c.Name.ToLower() == newCourse.Name.ToLower())
                    .Result.Any())
                return null;

            await _courseRepository.Add(newCourse);

            return newCourse;

        }

        public void Dispose()
        {
            _courseRepository?.Dispose();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<Course> GetById(int id)
        {
            return await _courseRepository.GetById(id);
        }

        public async Task<bool> Remove(Course course)
        {
            await _courseRepository.Remove(course);
            return true;

        }

        public async Task<IEnumerable<Course>> Search(string name)
        {
            return await _courseRepository
                            .Search(c => c.Name.Contains(name) || c.IconPath.Contains(name));
        }

        public async Task<Course> Update(Course course)
        {
            if (!_courseRepository
                    .Search(c => c.Id == course.Id).Result.Any())
                return null;

            await _courseRepository.Update(course);
            return course;
        }
    }
}