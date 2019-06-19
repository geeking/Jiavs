using Jiavs.Domain.Core.Commands;
using Jiavs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Commands.ArticleUsers
{
    public class ArticleUserCommand : BaseCommand
    {
        public Models.ArticleUser User { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}
