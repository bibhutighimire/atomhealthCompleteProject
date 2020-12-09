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
            ViewBag.userid= _userManager.GetUserId(HttpContext.User);
            AtomHealthUser user = _userManager.FindByIdAsync(userid).Result;
            //ViewBag.username = _userManager.GetUserAsync(HttpContext.User);
            //AtomHealthUser userName = _userManager.FindByNameAsync(userName).Result;
            return View(user);
        }

        public IActionResult EditUserProfile()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUserProfile(string id)
        {
            var edituser = await _userManager.FindByIdAsync(id);
            if(edituser==null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found.";
                return View("Not Found");
            }
            var model = new AtomHealthUser
            {
                FirstName = edituser.FirstName,
                MiddleName = edituser.MiddleName,
                LastName = edituser.LastName,
                Sex = edituser.Sex,
                DOB = edituser.DOB,
                Height = edituser.Height,
                Weight = edituser.Weight,
                PhoneNumber = edituser.PhoneNumber,
                Country = edituser.Country,
                HealthCarePlan = edituser.HealthCarePlan,
                HealthID = edituser.HealthID,
                FamilyDoctorName = edituser.FamilyDoctorName,
                EmergencyContactName = edituser.EmergencyContactName,
                EmergencyContactPhone = edituser.EmergencyContactPhone,
                MedicalConditions = edituser.MedicalConditions,
                Medicines = edituser.Medicines,
                Diseases = edituser.Diseases,
                Allergies = edituser.Allergies,
                PastSurgeries = edituser.PastSurgeries,
                FamilyHistory = edituser.FamilyHistory
            };
            return View(model);
           
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(AtomHealthUser model)
        {
            var edituser = await _userManager.FindByIdAsync(model.Id);

            if (edituser == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                edituser.FirstName = model.FirstName;
                edituser.MiddleName = model.MiddleName;
                edituser.LastName = model.LastName;
                edituser.Sex = model.Sex;
                edituser.DOB = model.DOB;
                edituser.Height = model.Height;
                edituser.Weight = model.Weight;
                edituser.PhoneNumber = model.PhoneNumber;
                edituser.Country = model.Country;
                edituser.HealthCarePlan = model.HealthCarePlan;
                edituser.HealthID = model.HealthID;
                edituser.FamilyDoctorName = model.FamilyDoctorName;
                edituser.EmergencyContactName = model.EmergencyContactName;
                edituser.EmergencyContactPhone = model.EmergencyContactPhone;
                edituser.MedicalConditions = model.MedicalConditions;
                edituser.Medicines = model.Medicines;
                edituser.Diseases = model.Diseases;
                edituser.Allergies = model.Allergies;
                edituser.PastSurgeries = model.PastSurgeries;
                edituser.FamilyHistory = model.FamilyHistory;

                var result = await _userManager.UpdateAsync(edituser);

                if (result.Succeeded)
                {
                    return RedirectToAction("UserProfile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
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
