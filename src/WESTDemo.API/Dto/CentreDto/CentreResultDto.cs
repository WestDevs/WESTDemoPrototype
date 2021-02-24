using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.CentreDto
{
    public class CentreResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrganisationResultDto Organisation { get; set; }

    }
}