using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Interfaces
{
    public interface ILearnerService : IDisposable
    {
        Task<Learner> Add(Learner learner);
        Task<List<Learner>> GetAll();
        Task<Learner> GetById(int id);
        Task<Learner> Update(Learner learner);
        Task<bool> Remove(Learner learner);
        Task<IEnumerable<Learner>> Search(string searchValue);
        Task<IEnumerable<Learner>> SearchLearners(string searchValue);
        Task<IEnumerable<Learner>> GetLearnersByOrganisation(int organisationId);
        Task<IEnumerable<Learner>> GetLearnersByGroup(int groupId);
        Task<Learner> GetLearnerByUser(int userId);
        Task<IEnumerable<Learner>> UpdateLearnerStatus(LearnerStatus learnerStatus);

    }
}