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
        public LearnerRepository(UsersContext context) : base(context) { }

        public override async Task<List<Learner>> GetAll()
        {
            return await GetLearnersFullDetail()
                .ToListAsync();
        }

        public async Task<Learner> GetLearnerByUser(int userId)
        {
            return await GetLearnersFullDetail()
                .FirstOrDefaultAsync(l => l.User.Id == userId);
        }

        public async Task<IEnumerable<Learner>> GetLearnersByGroup(int groupId)
        {
            return await GetLearnersFullDetail()
                .Where(l => l.GroupId == groupId)
                .ToListAsync();    
        }

        public async Task<IEnumerable<Learner>> GetLearnersByOrganisation(int organisationId)
        {
            return await GetLearnersFullDetail()
                .Where(l => l.User.OrganisationId == organisationId)
                .ToListAsync();
        }

        public override async Task<Learner> GetById(int id)
        {
            return await GetLearnersFullDetail()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Learner>> SearchLearners(string searchedValue)
        {
            return await GetLearnersFullDetail()
                .Where(l => l.User.Username.ToLower().Contains(searchedValue.ToLower()) ||
                    l.User.FirstName.ToLower().Contains(searchedValue.ToLower()) ||
                    l.User.LastName.ToLower().Contains(searchedValue.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Learner>> UpdateLearnerStatus(LearnerStatus learnerStatus)
        {
            Db.LearnerStatuses.Add(learnerStatus);
            await Db.SaveChangesAsync();

            return await GetLearnersFullDetail()
                .Where(l => l.Id == learnerStatus.LearnerId )
                .ToListAsync();
        }
        public IQueryable<Learner> GetLearnersFullDetail()
        {
            return  Db.Learners.AsNoTracking()
                .Include(l => l.User)
                .Include(l => l.Group)
                .Include(l => l.LearnerStatus).ThenInclude(lt => lt.Course)
                .Include(l => l.User.Organisation);
        }
    }

}