using AutoMapper;
using Jiavs.Application.Models;
using Jiavs.Domain.Commands.Articles;
using Jiavs.Domain.Commands.ArticleUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Application.AutoMapper.Profiles
{
    public class DtoToCommand : Profile
    {
        public DtoToCommand()
        {
            CreateMap<ArticleDto, ArticleAddCommand>()
                .ForCtorParam("content",opt=>opt.MapFrom(s=>s.Content))
                .ForCtorParam("settings",opt=>opt.MapFrom(s=>s.CanComment));
            CreateMap<ArticleUserDto, ArticleUserAddCommand>().ForCtorParam("user", opt => opt.MapFrom(src => src));
        }
    }
}