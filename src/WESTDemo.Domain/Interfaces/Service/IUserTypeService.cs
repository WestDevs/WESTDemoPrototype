using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IUserTypeService : IDisposable
    {
        Task<IEnumerable<UserType>> GetAll();
        Task<UserType> GetById(int id);
        Task<UserType> Add(UserType type);
        Task<UserType> Update(UserType type);
        Task<bool> Remove(UserType type);
        Task<IEnumerable<UserType>> Search(string name);
        Task<IEnumerable<UserType>> SearchUserTypes(string searchedValue);

    }
}