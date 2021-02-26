using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;

        }
        public async Task<Group> Add(Group newGroup)
        {
            if (_groupRepository
                  .Search(g => g.Name.ToLower() == newGroup.Name.ToLower())
                  .Result.Any())
                return null;

            await _groupRepository.Add(newGroup);

            return newGroup;
        }

        public void Dispose()
        {
            _groupRepository?.Dispose();
        }

        public async Task<List<Group>> GetAll()
        {
            return await _groupRepository.GetAll();
        }

        public async Task<Group> GetById(int id)
        {
            return await _groupRepository.GetById(id);
        }

        public async Task<bool> Remove(Group group)
        {
            await _groupRepository.Remove(group);
            return true;
        }

        public async Task<IEnumerable<Group>> Search(string searchedValue)
        {
            return await _groupRepository
                            .Search(g => g.Name.ToLower().Contains(searchedValue.ToLower()));
        }

        public async Task<Group> Update(Group group)
        {
            if (!_groupRepository
                    .Search(g => g.Id == group.Id).Result.Any())
                return null;

            await _groupRepository.Update(group);
            return group;

        }
    }
}