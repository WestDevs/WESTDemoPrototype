using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeService _typeService;
        private readonly IOrganisationService _orgService;
        public UserService(IUserRepository userRepository, IUserTypeService typeService, IOrganisationService orgService)
        {
            _orgService = orgService;
            _typeService = typeService;
            _userRepository = userRepository;
        }
        public async Task<User> Add(User user)
        {
            if (await _typeService.GetById(user.TypeId) == null) return null;
            if (await _orgService.GetById(user.OrganisationId) == null) return null;
            if (_userRepository.Search(b => b.Username == user.Username).Result.Any())  // uniqueness must be checked in username and email as well
                    return null;

            await _userRepository.Add(user);
            return user;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetUsersByOrganisation(int organisationId)
        {
            return await _userRepository.GetUsersByOrganisation(organisationId);
        }

        public async Task<IEnumerable<User>> GetUsersByUserType(int userTypeId)
        {
            return await _userRepository.GetUsersByUserType(userTypeId);
        }

        public async Task<bool> Remove(User user)
        {
            await _userRepository.Remove(user);
            return true;
        }

        public async Task<IEnumerable<User>> Search(string userName)
        {
            return await _userRepository
                            .Search(c => c.Username.Contains(userName) ||
                                 c.LastName.Contains(userName) ||
                                 c.FirstName.Contains(userName));
        }

        public async Task<IEnumerable<User>> SearchUsers(string searchedValue)
        {
            return await _userRepository.SearchUsers(searchedValue);
        }

        public async Task<User> Update(User updatedUser)
        {
            var user = await _userRepository.GetById(updatedUser.Id);

            if (user == null) return null;
            updatedUser.TypeId = user.TypeId;

            await _userRepository.Update(updatedUser);
            return user;
        }
    }
}
