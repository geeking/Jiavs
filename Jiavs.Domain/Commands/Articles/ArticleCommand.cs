using Jiavs.Domain.Core.Commands;
using Jiavs.Domain.Models.ValueObjects;

namespace Jiavs.Domain.Commands.Articles
{
    public abstract class ArticleCommand : BaseCommand
    {
        public uint Id { get; set; }

        /// <summary>
        /// 作者id
        /// </summary>
        public uint AuthorId { get; set; }

        public ArticleStatus Status { get; set; }

        public ArticleSettings Settings { get; set; }
        public ArticleContent Content { get; set; }
    }
}