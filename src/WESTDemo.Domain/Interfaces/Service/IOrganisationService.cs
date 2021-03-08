using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface IOrganisationService : IDisposable
    {
        Task<Organisation> Add(Organisation org);
        Task<IEnumerable<Organisation>> GetAll();
        Task<Organisation> GetById(int id);
        Task<Organisation> Update(Organisation org);
        Task<bool> Remove(Organisation org);
        Task<IEnumerable<Organisation>> Search(string name);
    }
}