using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Services
{
    public class CentreService : ICentreService
    {
        private readonly ICentreRepository _centreRepository;
        private readonly IOrganisationService _organisationService;
        public CentreService(ICentreRepository centreRepository, IOrganisationService organisationService)
        {
            _organisationService = organisationService;
            _centreRepository = centreRepository;
        }
        public async Task<Centre> Add(Centre newCentre)
        {
            if (_centreRepository
                    .Search(c => c.Name.ToLower() == newCentre.Name.ToLower())
                    .Result.Any())
                return null;

            var org = await _organisationService.GetById(newCentre.OrganisationId);
            if (org == null) return null;

            await _centreRepository.Add(newCentre);

            return newCentre;
        }

        public void Dispose()
        {
            _centreRepository?.Dispose();
        }

        public async Task<IEnumerable<Centre>> GetAll()
        {
            return await _centreRepository.GetAll();
        }

        public async Task<Centre> GetById(int id)
        {
            return await _centreRepository.GetById(id);
        }

        public async Task<IEnumerable<Centre>> GetCentresByOrganisation(int organisationId)
        {
            return await _centreRepository.GetCentresByOrganisation(organisationId);
        }

        public async Task<bool> Remove(Centre centre)
        {
            await _centreRepository.Remove(centre);
            return true;
        }

        public async Task<IEnumerable<Centre>> Search(string name)
        {
            return await _centreRepository.Search(c => c.Name.Contains(name));
        }

        public async Task<Centre> Update(Centre centre)
        {
            if (!_centreRepository
                    .Search(c => c.Id == centre.Id).Result.Any())
                return null;

            await _centreRepository.Update(centre);
            return centre;
        }
    }
}