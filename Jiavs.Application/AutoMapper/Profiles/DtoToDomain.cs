using AutoMapper;
using Jiavs.Application.Models;
using Jiavs.Domain.Models;
using System.Collections.Generic;

namespace Jiavs.Application.AutoMapper.Profiles
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<ArticleUserDto, ArticleUser>();
            CreateMap<List<ArticleDto>, List<Article>>();
        }
    }
}