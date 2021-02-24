using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }
        public async Task<UserType> Add(UserType type)
        {
            if (_userTypeRepository
                    .Search(b => b.Name.ToLower() == type.Name.ToLower())
                    .Result.Any())
                return null;

            await _userTypeRepository.Add(type);
            return type;
        }

        public void Dispose()
        {
            _userTypeRepository?.Dispose();
        }

        public async Task<IEnumerable<UserType>> GetAll()
        {
            return await _userTypeRepository.GetAll();
        }

        public async Task<UserType> GetById(int id)
        {
            return await _userTypeRepository.GetById(id);
        }

        public async Task<bool> Remove(UserType type)
        {
            await _userTypeRepository.Remove(type);
            return true;
        }

        public async Task<IEnumerable<UserType>> Search(string name)
        {
            return await _userTypeRepository.Search(ut => ut.Name.Contains(name));
        }

        public Task<IEnumerable<UserType>> SearchUserTypes(string searchedValue)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserType> Update(UserType type)
        {
            if (!_userTypeRepository
                    .Search(ut => ut.Id == type.Id).Result.Any())
                return null;
            
            await _userTypeRepository.Update(type);
            return type;
        }
    }
}