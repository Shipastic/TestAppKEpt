using AutoMapper;
using DataAccess.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.MappingDTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {          
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, UpdateCompanyDTO>().ReverseMap();
        }
    }
}
