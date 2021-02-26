using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;
using WESTDemo.Infrastracture.Context;

namespace WESTDemo.Infrastracture.Repositories
{
    public class LearnerRepository : Repository<Learner>, ILearnerRepository
    {
        public LearnerRepository(UsersContext context) : base(context)
        {
        }

        public override async Task<List<Learner>> GetAll()
        {
            return await Db.Learners.AsNoTracking()
                .Include(l => l.Group)
                .Include(l => l.LearnerStatus)
                // .Include(l => l.User).ThenInclude(u => u.Organisation)
                .Include(l => l.User.Organisation)
                .Include(l => l.User.Type)
                .ToListAsync();
        }

        public async Task<Learner> GetLearnerByUser(int userId)
        {
            // i dont see as useful yet
            // migth be useful
            return await Db.Learners.AsNoTracking()
                .FirstOrDefaultAsync(l => l.User.Id == userId);
        }

        public async Task<IEnumerable<Learner>> GetLearnersByGroup(int groupId)
        {
            return await Db.Learners.AsNoTracking()
                .Include(l => l.User)
                .Include(l => l.Group)
                .Include(l => l.LearnerStatus)
                .Where(l => l.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Learner>> GetLearnersByOrganisation(int organisationId)
        {
            return await Db.Learners.AsNoTracking()
                .Include(l => l.User)
                .Include(l => l.Group)
                .Include(l => l.LearnerStatus)
                .Where(l => l.User.OrganisationId == organisationId)
                .ToListAsync();
        }

        public override async Task<Learner> GetById(int id)
        {
            return await Db.Learners
                .Include(l => l.User)
                .Include(l => l.LearnerStatus)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Learner>> SearchLearners(string searchedValue)
        {
            return await Db.Learners
                .Include(l => l.User)
                .Where(l => l.User.Username.ToLower().Contains(searchedValue.ToLower()) ||
                    l.User.FirstName.ToLower().Contains(searchedValue.ToLower()) ||
                    l.User.LastName.ToLower().Contains(searchedValue.ToLower()))
                .ToListAsync();
        }

        public async Task UpdateLearnerStatus(LearnerStatus learnerStatus)
        {
            Db.LearnerStatuses.Add(learnerStatus);
            await Db.SaveChangesAsync();
        }
    }

}