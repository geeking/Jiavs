using System;

namespace Jiavs.Domain.Commands.Articles
{
    public class ArticleDeleteCommand : ArticleCommand
    {
        public ArticleDeleteCommand(uint articleId)
        {
            this.Id = articleId;
        }
        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}
