using System.Collections.Generic;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface ICourseService : IRepository<Course>
    {
        Task<Course> Add(Course entity);
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task<Course> Update(Course entity);
        Task<bool> Remove(Course entity);
        Task<IEnumerable<Course>> Search(string name);
    }
}