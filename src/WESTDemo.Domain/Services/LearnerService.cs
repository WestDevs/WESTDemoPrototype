using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;

namespace WESTDemo.Domain.Models
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;
        private readonly ICourseService _courseService;

        public LearnerService(ILearnerRepository learnerRepository,
                              IUserService userService,
                              IGroupService groupService,
                              ICourseService courseService)
        {
            _groupService = groupService;
            _userService = userService;
            _learnerRepository = learnerRepository;
            _courseService = courseService;
        }
        public async Task<Learner> Add(Learner newLearner)
        {
            // add user
            // if unsuccessfull return null
            // check valid group
            // check course valdity (course/status should not be added here i guess? hmm)
            // add learner
            var user = await _userService.Add(newLearner.User);
            if (user == null) return null;

            var group = await _groupService.GetById(newLearner.GroupId);
            if (group == null) return null;

            await _learnerRepository.Add(newLearner);

            return newLearner;
        }

        public void Dispose()
        {
            _learnerRepository?.Dispose();
        }

        public async Task<List<Learner>> GetAll()
        {
            return await _learnerRepository.GetAll();
        }

        public async Task<Learner> GetById(int id)
        {
            return await _learnerRepository.GetById(id);
        }

        public Task<Learner> GetLearnerByUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Learner>> GetLearnersByGroup(int groupId)
        {
            return await _learnerRepository.GetLearnersByGroup(groupId);
        }

        public async Task<IEnumerable<Learner>> GetLearnersByOrganisation(int organisationId)
        {
            return await _learnerRepository.GetLearnersByOrganisation(organisationId);
        }

        public async Task<bool> Remove(Learner learner)
        {
            // delete user too?
            await _learnerRepository.Remove(learner);
            await _userService.Remove(learner.User);
            return true;
        }

        public async Task<IEnumerable<Learner>> Search(string searchValue)
        {
            //approach#1
            //using users service, search by user type
            //approach#2
            //search by predicate, but username only
            // create a new method similar like searchusers
            return await _learnerRepository
                            .Search(l => l.User.Username.ToLower().Contains(searchValue.ToLower())
                                );
        }
        public async Task<IEnumerable<Learner>> SearchLearners(string searchValue)
        {
            //approach#1
            //using users service, search by user type
            //approach#2
            //search by predicate, but username only
            // create a new method similar like searchusers
            return await _learnerRepository
                            .SearchLearners(searchValue);
        }

        public async Task<Learner> Update(Learner learner)
        {
            // approach #1
            // accept UserID from request
            // derive learner id from userId
            // approach #2
            // accept LearnerID from request
            // derive User id from learnerId
            //approach#1
            // var originalLearner = await _learnerRepository
            //                     .GetLearnerByUser(learner.User.Id);
            // if(originalLearner == null) return null;
            // learner.Id = originalLearner.Id;
            
            //approach #2
            var originalLearner = await _learnerRepository.GetById(learner.Id);
            if (originalLearner == null) return null;
            
            learner.User.Id = originalLearner.User.Id;
            
            await _learnerRepository.Update(learner);
            return learner;

        }

        public async Task<Learner> UpdateLearnerStatus(LearnerStatus learnerStatus)
        {
            var learner = await _learnerRepository.GetById(learnerStatus.LearnerId);
            if (learner == null) return null;

            var course = await _courseService.GetById(learnerStatus.CourseId);
            if (course == null) return null;

            // course already assigned to learner?

            if (learner.LearnerStatus.Any(c => c.CourseId == learnerStatus.CourseId)) return null;

            // either create a new learner status, or just add use update learner? errr.. not sure

            //approach#1 , update learnerstatus

            await _learnerRepository.UpdateLearnerStatus(learnerStatus);

            return learner;
       
        }

    }
}