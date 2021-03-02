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
        private readonly IOrganisationService _organisationService;
        private const int LEARNER_USER_TYPE = 3;

        public LearnerService(ILearnerRepository learnerRepository,
                              IUserService userService,
                              IGroupService groupService,
                              ICourseService courseService,
                              IOrganisationService organisationService)
        {
            _groupService = groupService;
            _userService = userService;
            _learnerRepository = learnerRepository;
            _courseService = courseService;
            _organisationService = organisationService;
        }
        public async Task<Learner> Add(Learner newLearner)
        {
            newLearner.User.TypeId = LEARNER_USER_TYPE;

            if (await _userService.Add(newLearner.User) == null) return null;
            if (await _groupService.GetById(newLearner.GroupId) == null) return null;

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
            await _learnerRepository.Remove(learner);
            await _userService.Remove(learner.User);
            return true;
        }

        public async Task<IEnumerable<Learner>> Search(string searchValue)
        {
            return await _learnerRepository
                            .Search(l => l.User.Username.ToLower().Contains(searchValue.ToLower())
                                );
        }
        public async Task<IEnumerable<Learner>> SearchLearners(string searchValue)
        {
            return await _learnerRepository
                            .SearchLearners(searchValue);
        }

        public async Task<Learner> Update(Learner learner)
        {
            var originalLearner = await _learnerRepository.GetById(learner.Id);
            if (originalLearner == null) return null;
            
            learner.User.Id = originalLearner.User.Id;

            if (await _groupService.GetById(learner.GroupId) == null) return null;
            if (await _organisationService.GetById(learner.User.OrganisationId) == null) return null;

            await _learnerRepository.Update(learner);
            return learner;

        }

        public async Task<IEnumerable<Learner>> UpdateLearnerStatus(LearnerStatus learnerStatus)
        {
            var learner = await _learnerRepository.GetById(learnerStatus.LearnerId);
            if (learner == null) return null;

            var course = await _courseService.GetById(learnerStatus.CourseId);
            if (course == null) return null;

            if (learner.LearnerStatus.Any(c => c.CourseId == learnerStatus.CourseId)) return null;

            return await _learnerRepository.UpdateLearnerStatus(learnerStatus);

        }

    }
}