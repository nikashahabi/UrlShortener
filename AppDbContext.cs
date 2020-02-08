using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;
namespace URLConverter
{
    public class AppDbContext : DbContext{
        public DbSet<Url> UrlsEntities { get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Url>().ToTable("urlconverter");
            builder.Entity<Url>().HasKey(p => p.shortUrl);
            builder.Entity<Url>().Property(p=>p.longUrl).IsRequired();
            builder.Entity<Url>().Property(p=>p.shortUrl).IsRequired();
        }

    
        
    }
}