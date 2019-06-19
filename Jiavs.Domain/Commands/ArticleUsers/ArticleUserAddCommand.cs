using Jiavs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Commands.ArticleUsers
{
    public class ArticleUserAddCommand : ArticleUserCommand
    {
        public ArticleUserAddCommand(Models.ArticleUser user)
        {
            this.User = user;
        }
    }
}
