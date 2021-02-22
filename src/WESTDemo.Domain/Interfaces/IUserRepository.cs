using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        new Task<List<Users>> GetAll();
        new Task<Users> GetById(int id);
        Task<IEnumerable<Users>> SearchUsers(string searchedValue);
    }
}
