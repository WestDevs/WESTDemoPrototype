using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _orgRepository;
        public OrganisationService(IOrganisationRepository orgRepository)
        {
            _orgRepository = orgRepository;

        }
        public async Task<Organisation> Add(Organisation newOrg)
        {
            if (_orgRepository 
                    .Search(o => o.Name.ToLower() == newOrg.Name.ToLower())
                    .Result.Any()) 
                return null;

            await _orgRepository.Add(newOrg);
            return newOrg;
        }

        public void Dispose()
        {
            _orgRepository?.Dispose();
        }

        public async Task<IEnumerable<Organisation>> GetAll()
        {
            return await _orgRepository.GetAll();
        }

        public async Task<Organisation> GetById(int id)
        {
            return await _orgRepository.GetById(id);
        }

        public async Task<bool> Remove(Organisation org)
        {
            await _orgRepository.Remove(org);
            return true;

        }

        public async Task<IEnumerable<Organisation>> Search(string name)
        {
            return await _orgRepository.Search(o => o.Name.Contains(name));
        }

        public async Task<Organisation> Update(Organisation org)
        {
            if (!_orgRepository
                    .Search(o => o.Id == org.Id).Result.Any())
                return null;
            
            await _orgRepository.Update(org);
            return org;

        }
    }
}