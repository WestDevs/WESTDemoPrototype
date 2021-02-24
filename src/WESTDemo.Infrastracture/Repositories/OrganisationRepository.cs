using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;
using WESTDemo.Infrastracture.Context;
using WESTDemo.Infrastracture.Repositories;

namespace WESTDemo.Infrastracture.Repositories
{
    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        public OrganisationRepository(UsersContext context) : base(context) {}

        public override async Task<List<Organisation>> GetAll()
        {
            return await Db.Organisations.AsNoTracking()
                .Include(o => o.Centres)
                .ToListAsync();
        }
       
    }
}