using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        new Task<List<User>> GetAll();
        new Task<User> GetById(int id);
        Task<IEnumerable<User>> GetUsersByOrganisation(int organisationId);
        Task<IEnumerable<User>> GetUsersByUserType(int userTypeId);
        Task<IEnumerable<User>> SearchUsers(string searchedValue);
    }
}
