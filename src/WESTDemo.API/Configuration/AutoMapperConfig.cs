using AutoMapper;
using WESTDemo.API.Dto.CentreDto;
using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.API.Dto.UserDto;
using WESTDemo.API.Dto.UserTypeDto;
using WESTDemo.Domain.Models;

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
        }
    }
}
