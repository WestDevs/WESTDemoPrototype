using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;
using WESTDemo.Infrastracture.Context;

namespace WESTDemo.Infrastracture.Repositories
{
    public class CentreRepository: Repository<Centre>, ICentreRepository
    {
        public CentreRepository(UsersContext context) : base(context) {}

        public override async Task<List<Centre>> GetAll()
        {
            return await DbSet.AsNoTracking()
                .Include(c => c.Organisation)
                .ToListAsync();
        }
        public async Task<IEnumerable<Centre>> GetCentresByOrganisation(int organisationId)
        {
            return await DbSet.AsNoTracking()
                .Where(c => c.OrganisationId == organisationId)
                .ToListAsync();
        }
    }
}