using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jiavs.Application.IServices;
using Jiavs.Domain.Commands.Articles;
using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Core.NotificationHandlers;
using Jiavs.Domain.Core.Notifications;
using Jiavs.Domain.IRepositorys;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.DTO;
using MediatR;

namespace Jiavs.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly DomainErrorNotificationHandler _notificationHandler;

        public ArticleService(IArticleRepository articleRepository,
            IMapper mapper,
            IMediatorHandler bus,
            INotificationHandler<DomainErrorNotification> notificationHandler)
        {
            _articleRepository = articleRepository;
            this._mapper = mapper;
            this._bus = bus;
            this._notificationHandler = notificationHandler as DomainErrorNotificationHandler;
        }

        public ArticleDto GetArticle(uint id)
        {
            var article = _articleRepository.GetById(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;
        }

        public async Task<ArticleDto> GetArticleAsync(uint id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;
        }

        public PaginatedResultList<ArticleDto> GetArticlesSummary(ArticlePaginationParameter pagination)
        {
            var articles = _articleRepository.GetArticlesSummary(pagination);
            var articleDto = _mapper.Map<PaginatedResultList<ArticleDto>>(articles);
            return articleDto;
        }

        public async Task<PaginatedResultList<ArticleDto>> GetArticlesSummaryAsync(ArticlePaginationParameter pagination)
        {
            var articles = await _articleRepository.GetArticlesSummaryAsync(pagination);
            var articleDto = _mapper.Map<PaginatedResultList<ArticleDto>>(articles);
            return articleDto;
        }

        public bool Create(ArticleDto articleDto)
        {
            //var article = _mapper.Map<Article>(articleDto);
            var addCmd = _mapper.Map<ArticleAddCommand>(articleDto);
            _bus.SendCommand<ArticleAddCommand>(addCmd);
            return _notificationHandler.HasDomainErrors();
        }

        public bool Delete(uint id)
        {
            var delCmd = new ArticleDeleteCommand(id);
            _bus.SendCommand<ArticleDeleteCommand>(delCmd);
            return _notificationHandler.HasDomainErrors();
        }

        public bool Update(ArticleDto articleDto)
        {
            var updateCmd = _mapper.Map<ArticleUpdateCommand>(articleDto);
            _bus.SendCommand<ArticleUpdateCommand>(updateCmd);
            return _notificationHandler.HasDomainErrors();
        }
    }
}