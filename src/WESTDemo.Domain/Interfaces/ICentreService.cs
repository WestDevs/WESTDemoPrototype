using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface ICentreService : IDisposable
    {
        Task<Centre> Add(Centre newCentre);
        Task<IEnumerable<Centre>> GetAll();
        Task<Centre> GetById(int id);
        Task<Centre> Update(Centre centre);
        Task<bool> Remove(Centre centre); 
        Task<IEnumerable<Centre>> Search(string name);
        Task<IEnumerable<Centre>> GetCentresByOrganisation(int organisationId);
    }
}