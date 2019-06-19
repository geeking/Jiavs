using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Jiavs.Application.Models;
using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Models;

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
