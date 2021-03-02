using AutoMapper;
using WESTDemo.API.Dto.LearnerDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Configuration.LearnerMap
{
    public class LearnerAddConverter : ITypeConverter<LearnerAddDto, Learner>
    {
        private readonly IMapper _mapper;
        public LearnerAddConverter(IMapper mapper)
        {
            _mapper = mapper;

        }

        public Learner Convert(LearnerAddDto source, Learner destination, ResolutionContext context)
        {        
            var learner = new Learner();
            learner.User = _mapper.Map<User>(source.UserDetails);
            learner.GroupId = source.GroupId;

            return learner;
        }
    }
}