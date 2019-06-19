using AutoMapper;
using Jiavs.Application.IServices;
using Jiavs.Application.Models;
using Jiavs.Domain.Commands.ArticleUsers;
using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.NotificationHandlers;
using Jiavs.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Application.Services
{
    public class ArticleUserService : IArticleUserService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly DomainErrorNotificationHandler _notificationHandler;

        public ArticleUserService(IMapper mapper,
            IMediatorHandler bus,
            INotificationHandler<DomainErrorNotification> notificationHandler)
        {
            this._mapper = mapper;
            this._bus = bus;
            this._notificationHandler = notificationHandler as DomainErrorNotificationHandler;
        }

        public bool Create(ArticleUserDto userDto)
        {
            var addCommand = _mapper.Map<ArticleUserAddCommand>(userDto);
            _bus.SendCommand<ArticleUserAddCommand>(addCommand);
            return _notificationHandler.HasDomainErrors();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ArticleUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}