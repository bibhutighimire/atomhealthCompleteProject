using System;
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
     
        private readonly AtomHealthDBContext _context;
      
        private readonly ILogger<SubscribeController> _logger;

        public SubscribeController(ILogger<SubscribeController> logger, UserManager<AtomHealthUser> userManager, AtomHealthDBContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
         
        }

        public IActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");

                return View(_context.Subscribe.ToList());
            }
            return RedirectToAction("Signin", "SignUpAtom");

        }

        [HttpPost]
        public IActionResult Create(Subscribe s)
        {
            if (ModelState.IsValid)
            {
                Subscribe tblS = new Subscribe();
                var target = _context.Subscribe.Where(x => x.email == s.email).FirstOrDefault();
                if (target != null)
                {
                    ViewBag.alreadysub = "We already have your email address on our subscription list. Thanks!";
                    return View();
                }
                else
                {
                    tblS.email = s.email;
                    _context.Subscribe.Add(tblS);
                    _context.SaveChanges();
                    ViewBag.msg = " You are now Subscribed. Thanks!";
                    return View();
                }
            }
            return View();
        }
    }
}
