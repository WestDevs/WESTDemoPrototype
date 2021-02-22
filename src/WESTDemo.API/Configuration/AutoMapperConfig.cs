using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.API.Dto.User;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Users, UserAddDto>().ReverseMap();
            CreateMap<Users, UserEditDto>().ReverseMap();
            CreateMap<Users, UserResultDto>().ReverseMap();
        }
    }
}
