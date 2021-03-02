using AutoMapper;
using WESTDemo.API.Dto.GroupDto;
using WESTDemo.API.Dto.LearnerDto;
using WESTDemo.API.Dto.CourseDto;
using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace WESTDemo.API.Configuration.LearnerMap
{
    class LearnerResultConverter : ITypeConverter<Learner, LearnerResultDto>
    {
        private readonly IMapper _mapper;

        public LearnerResultConverter(IMapper mapper)
        {
            _mapper = mapper;

        }
        public LearnerResultDto Convert(Learner source,
                                        LearnerResultDto destination,
                                        ResolutionContext context)
        {
            var learnerStatusDto = new LearnerResultDto();

            learnerStatusDto.Id = source.Id;
            learnerStatusDto.Username = source.User.Username;
            learnerStatusDto.Firstname = source.User.FirstName;
            learnerStatusDto.Lastname = source.User.LastName;
            learnerStatusDto.Status = source.User.Status;
            learnerStatusDto.Organisation = _mapper.Map<OrganisationResultDto>(source.User.Organisation);
            learnerStatusDto.Group = _mapper.Map<GroupResultDto>(source.Group);

            var learnerStatus = source.LearnerStatus;
            if (learnerStatus != null && learnerStatus.Count > 0 )
                learnerStatusDto.LearnerStatus = _mapper.Map<ICollection<CourseResultDto>>(source.LearnerStatus.Select(ls => ls.Course));

            return learnerStatusDto;

        }

    }
}
