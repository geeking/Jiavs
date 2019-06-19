using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Commands.ArticleUsers
{
    public class ArticleUserUpdateCommand : ArticleUserCommand
    {
        public ArticleUserUpdateCommand(Models.ArticleUser user)
        {
            User = user;
        }
    }
}