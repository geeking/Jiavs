using Jiavs.Domain.Commands.ArticleUsers;
using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.CommandHandlers;
using Jiavs.Domain.Core.IRepositorys;
using Jiavs.Domain.IRepositorys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jiavs.Domain.CommandHandlers.ArticleUsers
{
    public class ArticleUserCommandHandlers : BaseHandler,
        IRequestHandler<ArticleUserAddCommand, bool>,
        IRequestHandler<ArticleUserUpdateCommand, bool>,
        IRequestHandler<ArticleUserDeleteCommand, bool>
    {
        private readonly IArticleUserRepository _articleUserRepository;

        public ArticleUserCommandHandlers(IArticleUserRepository articleUserRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler bus) : base(unitOfWork, bus)
        {
            this._articleUserRepository = articleUserRepository;
        }

        public Task<bool> Handle(ArticleUserAddCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return Task.FromResult(false);
            }
            _articleUserRepository.Add(request.User);
            var commitResult = Commit();
            return Task.FromResult(commitResult);
        }

        public Task<bool> Handle(ArticleUserDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return Task.FromResult(false);
            }
            _articleUserRepository.DeleteById(request.User.Id);
            var commitResult = Commit();
            return Task.FromResult(commitResult);
        }

        public Task<bool> Handle(ArticleUserUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return Task.FromResult(false);
            }
            _articleUserRepository.Update(request.User);
            var commitResult = Commit();
            return Task.FromResult(commitResult);
        }
    }
}