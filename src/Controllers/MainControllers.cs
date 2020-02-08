using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using UrlShortener.Services;
namespace UrlShortener.Controller
{
    [ApiController]
    [Route("/urls")]
    public class UrlGenerator : ControllerBase
    {
        public UrlService urlService;
        public UrlGenerator (UrlService urlService)
        {
            this.urlService = urlService;
        }

        [HttpPost]
        public ActionResult <Url> PostUrls ([FromBody]Url url)
        {
            if (Regex.IsMatch(url.longUrl, @"^(?:(?:https?|ftp)://)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$"))
            {
                bool check;
                string shortUrlString;
                do{
                    check=false;
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    char [] stringChars = new char[8];
                    var rand = new Random();
                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[rand.Next(chars.Length)];
                    }
                    shortUrlString =  new String(stringChars);
                    check = urlService.shortUrlExists(shortUrlString);
                }
                while (check==true);
                url.shortUrl = shortUrlString;
                urlService.addsToDatabase(url);
                return Ok(url);
            }
            else{
                return NotFound(url);
            }
        }
    }
    
    [ApiController]
    [Route("/redirect/{*shortDomain}")]
    public class RedirectUrl : ControllerBase
    {
        public UrlService urlService;
        public RedirectUrl (UrlService urlService)
        {
            this.urlService = urlService;
        }
        [HttpGet]
        public IActionResult redirect (string shortDomain)
        {
            if (urlService.shortUrlExists(shortDomain))
            {
                string[] prefixes = { "http", "https", "ftp" };
                if (prefixes.Any(prefix => shortDomain.StartsWith(prefix)))
                {
                    return Redirect(urlService.returnLongUrl(shortDomain));
                }
                else
                {
                    return Redirect("https://"+urlService.returnLongUrl(shortDomain));

                }
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}