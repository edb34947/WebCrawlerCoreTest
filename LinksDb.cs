using Microsoft.EntityFrameworkCore;

namespace WebCrawlerCore
{
    public class LinksDb : DbContext
    {
        public DbSet<LinkCheckResult> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=localhost;Database=Links;trusted_connection=true;";
            optionsBuilder.UseSqlServer(connection, options => { options.EnableRetryOnFailure(3); });
        }
    }
}
