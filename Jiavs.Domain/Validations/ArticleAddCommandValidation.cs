using Jiavs.Domain.Commands.Articles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Validations
{
    public class ArticleAddCommandValidation : ArticleCommandValidation<ArticleAddCommand>
    {
        public ArticleAddCommandValidation()
        {
            ValidateContent();
        }
    }
}
