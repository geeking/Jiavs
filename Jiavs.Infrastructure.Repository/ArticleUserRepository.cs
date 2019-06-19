using Jiavs.Domain.IRepositorys;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Infrastructure.Repository
{
    public class ArticleUserRepository : BaseRepository<ArticleUser>, IArticleUserRepository
    {
        public ArticleUserRepository(JiavsContext jiavsContext) : base(jiavsContext)
        {
        }
    }
}
