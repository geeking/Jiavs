using Jiavs.Domain.Models.ValueObjects;
using Jiavs.Domain.Validations;
using System;

namespace Jiavs.Domain.Commands.Articles
{
    public class ArticleAddCommand : ArticleCommand
    {
        public ArticleAddCommand(ArticleContent content, ArticleSettings settings, ArticleStatus status, uint authorId)
        {
            this.Content = content;
            this.Settings = settings;
            this.Status = status;
            this.AuthorId = authorId;
            if (this.Status != null)
            {
                Status.CreatedTime = DateTime.UtcNow;
                if (Status.IsPublished)
                {
                    Status.PublishTime = DateTime.UtcNow;
                }
            }
        }

        public override bool IsValid()
        {
            ValidationResult = new ArticleAddCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}