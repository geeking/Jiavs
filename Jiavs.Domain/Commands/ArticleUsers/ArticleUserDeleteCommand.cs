using Jiavs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Commands.ArticleUsers
{
    public class ArticleUserDeleteCommand : ArticleUserCommand
    {
        public ArticleUserDeleteCommand(uint userId)
        {
            User = new ArticleUser() { Id = userId };
        }
    }
}