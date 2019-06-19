using Jiavs.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Commands.Articles
{
    public class ArticleUpdateCommand : ArticleCommand
    {
        public ArticleUpdateCommand(uint articleId, ArticleContent content, ArticleSettings settings, ArticleStatus status)
        {
            this.Id = articleId;
            this.Content = content;
            this.Settings = settings;
            this.Status = status;
            if (this.Status != null)
            {
                Status.ModifyTime = DateTime.UtcNow;
            }
        }

        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}
