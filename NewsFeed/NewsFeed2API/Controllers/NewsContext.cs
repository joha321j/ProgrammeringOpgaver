using Microsoft.EntityFrameworkCore;
namespace NewsFeed2API
{
public class NewsContext : DbContext
{
    public NewsContext(DbContextOptions<NewsContext> options):base(options)
    {
        
    }

    public DbSet<News> news {get;set;}
}
}