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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Add(User user)
        {
            if (_userRepository.Search(b => b.FirstName == user.FirstName
                                        && b.LastName == user.LastName).Result.Any())
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
            return await _userRepository.Search(c => c.FirstName.Contains(userName));
        }

        public async Task<IEnumerable<User>> SearchUsers(string searchedValue)
        {
            return await _userRepository.SearchUsers(searchedValue);
        }

        public async Task<User> Update(User user)
        {
            if (_userRepository.Search(b => b.FirstName == user.FirstName && b.Id != user.Id).Result.Any())
                return null;

            await _userRepository.Update(user);
            return user;
        }
    }
}
