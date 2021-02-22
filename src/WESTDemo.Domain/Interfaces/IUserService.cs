using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<Users>> GetAll();
        Task<Users> GetById(int id);
        Task<Users> Add(Users user);
        Task<Users> Update(Users user);
        Task<bool> Remove(Users user);
        Task<IEnumerable<Users>> Search(string userName);
        Task<IEnumerable<Users>> SearchUsers(string searchedValue);
    }
}
