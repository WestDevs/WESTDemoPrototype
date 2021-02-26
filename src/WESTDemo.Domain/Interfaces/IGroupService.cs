using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IGroupService : IDisposable
    {
        Task<Group> Add(Group group);
        Task<List<Group>> GetAll();
        Task<Group> GetById(int id);
        Task<Group> Update(Group group);
        Task<bool> Remove(Group group);
        Task<IEnumerable<Group>> Search(string searchedValue);

    }
}