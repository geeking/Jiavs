using AutoMapper;
using Jiavs.Application.IServices;
using Jiavs.Application.Services;
using Jiavs.Domain.CommandHandlers.Articles;
using Jiavs.Domain.CommandHandlers.ArticleUsers;
using Jiavs.Domain.Commands.Articles;
using Jiavs.Domain.Commands.ArticleUsers;
using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.IRepositorys;
using Jiavs.Domain.Core.NotificationHandlers;
using Jiavs.Domain.Core.Notifications;
using Jiavs.Domain.IRepositorys;
using Jiavs.Infrastructure.Bus;
using Jiavs.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jiavs.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static void AddApplicationInjection(this IServiceCollection services)
        {
            //消息组件
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            //AutoMapper组件
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapper.Config.RegisterProfile();
            //对外服务接口
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleUserService, ArticleUserService>();
            //Domain
            services.AddScoped<IRequestHandler<ArticleAddCommand, bool>, ArticleCommandHandlers>();
            services.AddScoped<IRequestHandler<ArticleUpdateCommand, bool>, ArticleCommandHandlers>();
            services.AddScoped<IRequestHandler<ArticleDeleteCommand, bool>, ArticleCommandHandlers>();
            services.AddScoped<IRequestHandler<ArticleUserAddCommand, bool>, ArticleUserCommandHandlers>();
            services.AddScoped<INotificationHandler<DomainErrorNotification>, DomainErrorNotificationHandler>();
            //Repository
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleUserRepository, ArticleUserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}