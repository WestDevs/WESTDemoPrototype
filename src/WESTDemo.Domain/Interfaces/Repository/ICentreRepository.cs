using WESTDemo.Domain.Models;
using WESTDemo.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace WESTDemo.Domain.Interfaces
{
    public interface ICentreRepository : IRepository<Centre>
    {
        new Task<List<Centre>> GetAll();
        Task<IEnumerable<Centre>> GetCentresByOrganisation(int organisationId);
    }
}