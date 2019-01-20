using System;
using AutoMapper;
using ComicBooksAPI.Comics.Models;
using ComicBooksAPI.Titles.Models;
using ComicBooksAPI.Users.Models;

namespace ComicBooksAPI.DAL
{
    public static class Mappings
    {
        public static readonly Action<IMapperConfigurationExpression> Map = m =>
        {
            m.CreateMap<ComicExtendedDto, Comic>();
            m.CreateMap<Comic, ComicExtendedDto>();

            m.CreateMap<ComicDto, Comic>();
            m.CreateMap<Comic, ComicDto>();

            m.CreateMap<Title, TitleDto>();
            m.CreateMap<TitleDto, Title>();

            m.CreateMap<TitleExtendedDto, Title>();
            m.CreateMap<Title, TitleExtendedDto>();

            m.CreateMap<User, UserRegistrationDto>();
            m.CreateMap<UserRegistrationDto, User>();

            m.CreateMap<User, UserDto>();
            m.CreateMap<UserDto, User>();
            
            m.CreateMap<User, UserLoginDto>();
            m.CreateMap<UserLoginDto, User>();
        };
    }
}