using Jiavs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Jiavs.Infrastructure.Repository.Context
{
    public class JiavsContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleUser> Authors { get; set; }

        public JiavsContext(DbContextOptions<JiavsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Articles);

            builder.Entity<Article>().OwnsOne(x => x.Settings);
            builder.Entity<Article>().OwnsOne(x => x.Status);
            builder.Entity<Article>().OwnsOne(x => x.Content);
        }
    }
}