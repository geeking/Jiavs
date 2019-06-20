# Jiavs
A blog website with DDD, CQRS and Event Sourcing
>尚在不断完善中  
>In development, not yet finished
# 00 Jiavs.Domain.Core
定义了一系列领域对象、进程内通讯组件（`MediatR`）和仓储的基础接口或抽象类  
Some base interfaces or abstract classes for domain objects and In-process messaging(dependence `MediatR`) and base repository.

```
---Jiavs.Domain.Core
    |---Bus
    |   |---IMediatorHandler.cs             //消息中介者接口，SendCommand or RaiseEvent
    |---CommandHandlers
    |   |---BaseHandler.cs                  //封装领域指令处理器的公共能力
    |---Commands
    |   |---BaseCommand.cs                  //领域指令的抽象基类，单播
    |---Events
    |   |---BaseEvent.cs                    //领域事件的抽象基类，多播
    |---IRepository
    |   |---IBaseRepository.cs              //仓储的基础接口
    |   |---IUnitOfWork.cs                  //统一提交模型基础接口
    |---Models
    |   |---AggregationRoot.cs              //聚合根抽象模型
    |   |---IEntity.cs                      //领域实体抽象接口
    |   |---PaginatedResultList.cs          //分页结果集基础泛型类
    |   |---PaginationBase.cs               //分页查询请求基类
    |   |---ValueObject.cs                  //领域值对象抽象约束
    |---NotificationHandlers
    |   |---DomainErrorNotificationHandler.cs   //领域异常通知处理器基类
    |---Notifications
    |   |---DomainErrorNotification.cs          //领域异常通知消息对象

```

# 01 Jiavs.Domain
领域的主体部分，对业务进行组织、划分。依赖`Domain.Core`。  
The main project of Domain,organize and divide business.Dependent on `Domain.Core`.

```
---Jiavs.Domain
    |---CommandHandlers
        |---Articles
            |---ArticleCommandHandlers.cs           //文章领域命令处理器
        |---ArticleUsers
            |---ArticleUserCommandHandlers.cs       //文章用户（指文章发布者）领域命令处理器
    |---Commands
        |---Articles
            |---ArticleAddCommand.cs                //添加文章命令
            |---ArticleCommand.cs                   //文章命令基类
            |---ArticleDeleteCommand.cs             //删除文章命令
            |---ArticleUpdateCommand.cs             //更新文章命令
        |---ArticleUsers
            |---ArticleUserAddCommand.cs
            |---ArticleUserCommand.cs
            |---ArticleUserDeleteCommand.cs
            |---ArticleUserUpdateCommand.cs
    |---EventHandlers
    |---Events          //(仍有部分在设计，如浏览文章产生的一些事件，可以基于此做浏览计数或历史记录等业务)
    |---IRepositorys
        |---IArticleRepository.cs               //文章仓储抽象接口
        |---IArticleUserRepository.cs           //文章用户仓储抽象接口
    |---Models
        |---ValueObjects
            |---ArticleContent.cs
            |---ArticleSettings.cs
            |---ArticleStatus.cs
            |---LoginHistory.cs
        |---Article.cs                  //文章领域聚合根对象
        |---ArticleUser.cs              //文章用户领域聚合根对象
        |---ArticlePaginationParameter.cs       //文章分页查询参数模型
    |---Validations         //(只写了几个，有待后续添加)
        |---ArticleAddCommandValidation.cs          //文章添加命令合法性验证器
        |---ArticleCommandValidation.cs             //文章命令泛型验证器，使用FluentValidation组件
```

# 02 Jiavs.Infrastructure

# 03 Jiavs.Infrastructure.Identity

# 04 Jiavs.Infrastructure.Repository

# 05 Jiavs.Infrastructure.Security

# 06 Jiavs.Application

# 07 Jiavs.MVC

# 08 RoadMap
>若考虑分布式部署或拆分为微服务，可按需将领域拆分，此时需特别关注领域边界的划分。另外，在分布式系统中，单纯的进程内消息组件（如目前架构中使用的MediatR）将无法满足要求，此时应当引入分布式消息总线或分布式事务解决方案，于此，推荐使用[CAP](!https://github.com/dotnetcore/CAP)，该组件为杨晓东大神开发，集分布式消息、事务于一体的轻量级解决方案，易于使用。

>对于站内搜索，可选用合适的分词组件，可直接集成进来或单独部署。若单独部署，需在文章创建或更新时，触发一个分布式消息，在分词项目内分词并维护好索引，在搜索时即可检索出索引并使用。

>性能优化，可使用Redis缓存部分文章（如前10页），而后在领域仓储的具体实现层`Infrastructure.Repository`添加对Redis的访问。另外不要忘了对缓存数据的更新和清理工作。