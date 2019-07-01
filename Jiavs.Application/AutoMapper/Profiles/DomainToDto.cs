using AutoMapper;
using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.DTO;
using System.Collections.Generic;

namespace Jiavs.Application.AutoMapper.Profiles
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleUser, ArticleUserDto>();
            CreateMap<List<Article>, List<ArticleDto>>();
            CreateMap<PaginatedResultList<Article>, PaginatedResultList<ArticleDto>>();
        }
    }
}