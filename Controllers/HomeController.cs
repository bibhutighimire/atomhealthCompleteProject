using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtomHealth.Models;
using System.Net;
using Newtonsoft.Json;
using static AtomHealth.Models.News;
using Microsoft.AspNetCore.Identity;
using AtomHealth.Areas.Identity.Data;

namespace AtomHealth.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly UserManager<AtomHealthUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<AtomHealthUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           return View();
        }



        public IActionResult UserProfile()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            AtomHealthUser user = _userManager.FindByIdAsync(userid).Result;
            //ViewBag.username = _userManager.GetUserAsync(HttpContext.User);
            //AtomHealthUser userName = _userManager.FindByNameAsync(userName).Result;
            return View(user);
        }

        public IActionResult OurSolution()
        {
            return View();
        }

        public IActionResult JoinUs()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult News()
        {
            string url = string.Format("http://newsapi.org/v2/top-headlines?country=ca&category=health&apiKey=aa93bb23607b4762b8ce8a1704b8e5cb");


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var jsonstring = JsonConvert.DeserializeObject<Example>(json);

                var a = jsonstring.articles;

                return View(a);
            }
        }

        public IActionResult Patient()
        {
            return View();
        }

        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult EMR()
        {
            return View();
        }

        public IActionResult Insurance()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
