using AcademyApi.Data.Entities;
using Api.Data.Entities;
using Api.Resources.Category;
using Api.Resources.Product;
using Api.Resources.User;
using AutoMapper;
using System;
using System.Linq;

namespace Api.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterResource, User>()
                .ForMember(d => d.Status, opt => opt.MapFrom(src => true))
                .ForMember(d => d.AddedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.AddedBy, opt => opt.MapFrom(src => "System"))
                .ForMember(d => d.AddedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.Password, opt => opt.MapFrom(src => CryptoHelper.Crypto.HashPassword(src.Password)))
                .ForMember(d => d.Token, opt => opt.MapFrom(src => CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString())));

            CreateMap<User, UserResource>()
                .ForMember(d => d.RegisterDate, opt => opt
                .MapFrom(src => src.AddedDate
                .ToString("dd.MM.yyyy")));

            CreateMap<Category, CategoryResource>()
                .ForMember(d => d.Products, opt => opt
                .MapFrom(src => src.Products
                .Select(x => x.Name)));

            CreateMap<Product, ProductResource>();
        }
    }
}