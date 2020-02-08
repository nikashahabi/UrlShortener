using UrlShortener.Models;
using System.Linq; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UrlShortener.Services;

namespace UrlShortener.Services
{
    public class UrlService
    {
        public AppDbContext dbContext { get; set; }

        public UrlService (AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public bool shortUrlExists (string shortString)
        {
            Task <bool> search;
            search = dbContext.UrlsEntities.AnyAsync(p => p.shortUrl == shortString);
            search.Wait();
            return search.Result;
        }

        public void addsToDatabase (Url url)
        {
            dbContext.UrlsEntities.Add(url);
            dbContext.SaveChanges();
        
        }
        public string returnLongUrl (string shortUrl)
        {
            var search = dbContext.UrlsEntities.Where(p => p.shortUrl == shortUrl).Single();
            return search.longUrl;
        }
    }

}