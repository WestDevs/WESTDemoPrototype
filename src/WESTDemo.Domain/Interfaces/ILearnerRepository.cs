using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface ILearnerRepository : IRepository<Learner>
    {
        new Task<List<Learner>> GetAll();
        Task<IEnumerable<Learner>> GetLearnersByOrganisation(int organisationId);
        Task<IEnumerable<Learner>> GetLearnersByGroup(int groupId);
        Task<Learner> GetLearnerByUser(int userId);
        new Task<Learner> GetById(int id);
        Task<IEnumerable<Learner>> SearchLearners(string searchedValue);
        Task UpdateLearnerStatus(LearnerStatus learnerStatus);
    }
}