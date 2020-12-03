/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Areas.Identity.Data;
using AtomHealth.Areas.Identity.Pages.Account;
using AtomHealth.Data;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AtomHealth.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly UserManager<AtomHealthUser> _userManager;
        private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<AtomHealthUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<AtomHealthUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        private readonly AtomHealthDBContext _context;

        public SubscribeController(AtomHealthDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");

                return View(_context.tblSubscribe.ToList());
            }
            return RedirectToAction("Signin", "SignUpAtom");
          
        }
        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subscribe s)
        {
            Subscribe tblS = new Subscribe();
            var target = _context.tblSubscribe.Where(x => x.email == s.email).FirstOrDefault();
            if(target!=null)
            {
                ViewBag.alreadysub = "We already have your email address on our subscription list. Thanks!";
                return View();
            }
            else
            {
                tblS.email = s.email;
                _context.tblSubscribe.Add(tblS);
                _context.SaveChanges();
                ViewBag.msg = " You are now Subscribed. Thanks!";
                return View();
            }           
        }
    }
}
*/