using System.Collections.Generic;

namespace Jiavs.Infrastructure.Security.BrowerHeaders.CSP
{
    public sealed class CspDirectiveBuilder
    {
        internal CspDirectiveBuilder()
        {
        }

        internal List<string> Sources { get; set; } = new List<string>();

        public CspDirectiveBuilder AllowSelf() => Allow("'self'");

        public CspDirectiveBuilder AllowNone() => Allow("none");

        public CspDirectiveBuilder AllowAny() => Allow("*");

        public CspDirectiveBuilder Allow(string source)
        {
            this.Sources.Add(source);
            return this;
        }
    }
}