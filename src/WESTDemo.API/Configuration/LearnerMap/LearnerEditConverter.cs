using AutoMapper;
using WESTDemo.API.Dto.LearnerDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Configuration.LearnerMap
{
    public class LearnerEditConverter : ITypeConverter<LearnerEditDto, Learner>
    {
        private readonly IMapper _mapper;
        public LearnerEditConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Learner Convert(LearnerEditDto source, Learner destination, ResolutionContext context)
        {
            var learner = new Learner();
            
            learner.User = _mapper.Map<User>(source);
            learner.User.TypeId = source.TypeId;
            learner.GroupId = source.GroupId;
            learner.Id = source.Id;
            
            return learner;
        }
    }
}