using AutoMapper;
using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.DTO;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Jiavs.Application.AutoMapper.Profiles
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Content.Title))
                .ForMember(dst => dst.CoverUrl, opt => opt.MapFrom(src => src.Content.CoverUrl))
                .ForMember(dst => dst.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dst => dst.VisitCount, opt => opt.MapFrom(src => src.Status.VisitCount))
                .ForMember(dst => dst.IsOriginal, opt => opt.MapFrom(src => src.Status.IsOriginal))
                .ForMember(dst => dst.PublishTime, opt => opt.MapFrom(src => src.Status.PublishTime))
                .ForMember(dst => dst.Summary, opt => opt.MapFrom(src => src.Content.Summary))
                .ForMember(dst => dst.Content, opt => opt.MapFrom(src => src.Content.ContentHtml))
                .ForMember(dst => dst.CanComment, opt => opt.MapFrom(src => src.Settings.CanComment))
                .ForMember(dst => dst.CanGrade, opt => opt.MapFrom(src => src.Settings.CanGrade));
            CreateMap<ArticleUser, ArticleUserDto>();
            CreateMap<List<Article>, List<ArticleDto>>();
            CreateMap<PaginatedResultList<Article>, PaginatedResultList<ArticleDto>>()
                .ForCtorParam("pagination", opt => opt.MapFrom(src => src.Pagination))
                .ForCtorParam("data", opt => opt.MapFrom(src => src))
                .ForCtorParam("totalItemsCount", opt => opt.MapFrom(src => src.TotalItemsCount));
        }
    }
}