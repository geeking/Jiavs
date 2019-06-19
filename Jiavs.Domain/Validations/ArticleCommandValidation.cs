using FluentValidation;
using Jiavs.Domain.Commands.Articles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Validations
{
    public class ArticleCommandValidation<T> : AbstractValidator<T> where T : ArticleCommand
    {
        public ArticleCommandValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
        }

        protected void ValidateContent()
        {
            //var nullErrorMessage= "The { PropertyName} can't be null";
            //var emptyErrorMessage = "The {PropertyName} can't be empty";
            //var lengthErrorMessage = "The {PropertyName} length must between {MinLength} and {MaxLength}";
            RuleFor(a => a.Content).NotNull();
            RuleFor(a => a.Content.Title).NotEmpty().Length(1, 100);
            RuleFor(a => a.Content.Summary).Length(0, 2000);
            RuleFor(a => a.Content.ContentHtml).Length(0, 60000);
            RuleFor(a => a.Content.ContentMarkdown).Length(0, 60000);

        }
    }
}
