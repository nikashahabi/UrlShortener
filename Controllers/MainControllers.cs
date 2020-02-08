using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace UrlShortener.Controller
{
    [ApiController]
    [Route("/urls")]
    public class UrlGenerator : ControllerBase
    {

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
                    //check = urlService.shortUrlExists(shortUrlString);
                }
                while (check==true);
                url.shortUrl = shortUrlString;
                //urlService.addsToDatabase(url);
                return Ok(url);
            }
            else{
                return NotFound(url);
            }
        }
    }
}