using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jiavs.Domain.Commands.Articles;
using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.CommandHandlers;
using Jiavs.Domain.Core.IRepositorys;
using Jiavs.Domain.IRepositorys;
using Jiavs.Domain.Models;
using Jiavs.Domain.Models.ValueObjects;
using MediatR;

namespace Jiavs.Domain.CommandHandlers.Articles
{
    public class ArticleCommandHandlers : BaseHandler, IRequestHandler<ArticleAddCommand, bool>, IRequestHandler<ArticleUpdateCommand, bool>, IRequestHandler<ArticleDeleteCommand, bool>
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleCommandHandlers(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IMediatorHandler bus) : base(unitOfWork, bus)
        {
            this._articleRepository = articleRepository;
        }

        /// <summary>
        /// 添加文章命令处理器
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(ArticleAddCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return Task.FromResult(false);
            }
            var content = new ArticleContent(request.Content.Title, request.Content.CoverUrl, request.Content.Summary, request.Content.ContentHtml, request.Content.ContentMarkdown);
            var settings = new ArticleSettings();
            var status = new ArticleStatus();
            var newArticle = new Article(content, status, settings, request.AuthorId);
            _articleRepository.Add(newArticle);

            var commitResult = Commit();

            return Task.FromResult(commitResult);
        }

        /// <summary>
        /// 更新文章命令处理器
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(ArticleUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除文章命令处理器
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(ArticleDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}