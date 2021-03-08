using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<bool> Remove(User user);
        Task<IEnumerable<User>> GetUsersByOrganisation(int organisationId);
        Task<IEnumerable<User>> GetUsersByUserType(int userTypeId);
        Task<IEnumerable<User>> Search(string userName);
        Task<IEnumerable<User>> SearchUsers(string searchedValue);
    }
}
