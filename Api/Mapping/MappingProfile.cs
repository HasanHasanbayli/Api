using AcademyApi.Data.Entities;
using Api.Resources.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>()
                .ForMember(d => d.RegisterDate, opt => opt
                .MapFrom(src => src.AddedDate
                .ToString("dd.MM.yyyy")));
        }
    }
}
