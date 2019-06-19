using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Infrastructure.Security.XssFilter
{
    public static class HtmlSanitizerFactory
    {
        private static HtmlSanitizer _sanitizer;

        public static HtmlSanitizer GetHtmlSanitizer()
        {
            if (_sanitizer == null)
            {
                _sanitizer = new HtmlSanitizer();
                _sanitizer.AllowedAttributes.Add("class");
            }
            return _sanitizer;
        }
    }
}
