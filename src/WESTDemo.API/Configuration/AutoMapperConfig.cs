using AutoMapper;
using WESTDemo.API.Dto.GroupDto;
using WESTDemo.API.Dto.LearnerDto;
using WESTDemo.API.Dto.CentreDto;
using WESTDemo.API.Dto.CourseDto;
using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.API.Dto.UserDto;
using WESTDemo.API.Dto.UserTypeDto;
using WESTDemo.Domain.Models;
using WESTDemo.API.Dto.LearnerStatusDto;

namespace WESTDemo.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserAddDto>().ReverseMap();
            CreateMap<User, UserEditDto>().ReverseMap();
            CreateMap<User, UserResultDto>().ReverseMap();
            CreateMap<UserType, UserTypeAddDto>().ReverseMap();
            CreateMap<UserType, UserTypeEditDto>().ReverseMap();
            CreateMap<UserType, UserTypeResultDto>().ReverseMap();
            CreateMap<Organisation, OrganisationAddDto>().ReverseMap();
            CreateMap<Organisation, OrganisationEditDto>().ReverseMap();
            CreateMap<Organisation, OrganisationResultDto>().ReverseMap();
            CreateMap<Centre, CentreAddDto>().ReverseMap();
            CreateMap<Centre, CentreEditDto>().ReverseMap();
            CreateMap<Centre, CentreResultDto>().ReverseMap();
            CreateMap<Course, CourseAddDto>().ReverseMap();
            CreateMap<Course, CourseEditDto>().ReverseMap();
            CreateMap<Course, CourseResultDto>().ReverseMap();
            CreateMap<Group, GroupAddDto>().ReverseMap();
            CreateMap<Group, GroupEditDto>().ReverseMap();
            CreateMap<Group, GroupResultDto>().ReverseMap();
            CreateMap<Learner, LearnerAddDto>().ReverseMap();
            CreateMap<Learner, LearnerEditDto>().ReverseMap();
            CreateMap<Learner, LearnerResultDto>().ReverseMap();
            CreateMap<LearnerStatus, LearnerStatusAddDto>().ReverseMap();
            CreateMap<LearnerStatus, LearnerStatusResultDto>().ReverseMap();
        }
    }
}
