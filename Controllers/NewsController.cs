using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JWTAuthentication_TokenBarer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]

    public class NewsController : ControllerBase
    {
       

        private static readonly string[] title = new[]
       {
            "Facebook takes the EU to court over privacy spat", "Covid-19 the 'most severe' crisis we've faced", "Wuhan journey: 'I regret it with all my heart", "The millions of Americans 'hanging by a thread",  "A National Guard major will say that police escalated the 1 June protest in Lafayette Park.","Celebs seek stolen teddy with dying mum’s voice"
        };

        private static readonly string[] description = new[]
      {
            "Facebook takes the EU to court over privacy spat Descirtion", "Covid-19 the 'most severe' crisis we've faced", "Wuhan journey: 'I regret it with all my heart", "White House's Lafayette protest account disputed",  "A National Guard major will say that police escalated the 1 June protest in Lafayette Park.", "Celebs seek stolen teddy with dying mum’s voice"
        };

        private static readonly string[] ImgURL = new[]
      {
            "https://ichef.bbci.co.uk/news/1024/branded_news/90B9/production/_107794073_gettyimages-1131586581.jpg", "https://ichef.bbci.co.uk/news/1024/branded_news/90B9/production/_107794073_gettyimages-1131586581.jpg", "https://ichef.bbci.co.uk/news/1024/branded_news/90B9/production/_107794073_gettyimages-1131586581.jpg", "https://ichef.bbci.co.uk/news/1024/branded_news/90B9/production/_107794073_gettyimages-1131586581.jpg",  "https://ichef.bbci.co.uk/news/1024/branded_news/90B9/production/_107794073_gettyimages-1131586581.jpg", "https://ichef.bbci.co.uk/news/1024/branded_news/90B9/production/_107794073_gettyimages-1131586581.jpg"
        };


        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<News> Get()
        {
 

            return Enumerable.Range(1, 5).Select(index => new News
            { 
                Date = DateTime.Now.AddDays(index),
                Title = title[index],
                NewsID = index,
                urlToImage = ImgURL[index],
                Description = description[index]
            })
            .ToArray();
        }
    }
}
