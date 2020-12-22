﻿using System;
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
using Microsoft.AspNetCore.Authorization;
using static AtomHealth.Areas.Identity.Pages.Account.ExternalLoginModel;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using AtomHealth.Data;

namespace AtomHealth.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly UserManager<AtomHealthUser> _userManager;
        private readonly SignInManager<AtomHealthUser> _SignInManager;
        private readonly AtomHealthDBContext _context;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<AtomHealthUser> userManager, AtomHealthDBContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            //_signInManager = signInManager;
        }

        public IActionResult Index()
        {
           return View();
        }

        /*  [HttpGet]
         [AllowAnonymous]
         public async Task<IActionResult> Login(string returnUrl)
         {
             InputModel model = new InputModel
             {
                 ReturnUrl = returnUrl,
                 ExternalLogins =
                 (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
             };

             return View(model);
         }

        [AllowAnonymous]
         [HttpPost]
         public IActionResult ExternalLogin(string provider, string returnUrl)
         {
             var redirectUrl = Url.Action("ExternalLoginCallback", "Home",
                                 new { ReturnUrl = returnUrl });
             var properties = _signInManager
                 .ConfigureExternalAuthenticationProperties(provider, redirectUrl);
             return new ChallengeResult(provider, properties);
         }
 */

        /*  [AllowAnonymous]
          public async Task<IActionResult>
              ExternalLoginCallback(string returnUrl = null, string remoteError = null)
          {
              returnUrl = returnUrl ?? Url.Content("~/");

              InputModel loginViewModel = new InputModel
              {
                  ReturnUrl = returnUrl,
                  ExternalLogins =
                          (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
              };

              if (remoteError != null)
              {
                  ModelState
                      .AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                  return View("Login", loginViewModel);
              }

              // Get the login information about the user from the external login provider
              var info = await _signInManager.GetExternalLoginInfoAsync();
              if (info == null)
              {
                  ModelState
                      .AddModelError(string.Empty, "Error loading external login information.");

                  return View("Login", loginViewModel);
              }

              // If the user already has a login (i.e if there is a record in AspNetUserLogins
              // table) then sign-in the user with this external login provider
              var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                  info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

              if (signInResult.Succeeded)
              {
                  return LocalRedirect(returnUrl);
              }
              // If there is no record in AspNetUserLogins table, the user may not have
              // a local account
              else
              {
                  // Get the email claim value
                  var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                  if (email != null)
                  {
                      // Create a new user without password if we do not have a user already
                      var user = await _userManager.FindByEmailAsync(email);

                      if (user == null)
                      {
                          user = new AtomHealthUser
                          {
                              UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                              Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                          };

                          await _userManager.CreateAsync(user);
                      }

                      // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                      await _userManager.AddLoginAsync(user, info);
                      await _signInManager.SignInAsync(user, isPersistent: false);

                      return LocalRedirect(returnUrl);
                  }

                  // If we cannot find the user email we cannot continue
                  ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                  ViewBag.ErrorMessage = "Please contact support on atomhealth1@gmail.com";

                  return View("Error");
              }
          }*/



        public async Task<IActionResult> UserProfile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.id = user.Id;
            
            //ViewBag.username = _userManager.GetUserAsync(HttpContext.User);
            //AtomHealthUser userName = _userManager.FindByNameAsync(userName).Result;
            return View(user);
        }

        

        [HttpGet]
        public async Task<IActionResult> EditUserProfile(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.id = user.Id;
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found.";
                return View("Not Found");
            }
           
            return View(user);
           
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
                edituser.Gender = model.Gender;
                
                edituser.Height = model.Height;
                edituser.Weight = model.Weight;
                edituser.DOB = model.DOB;
                edituser.Country = model.Country;
                edituser.Province = model.Province;
                edituser.City = model.City;
                edituser.AddressLineOne = model.AddressLineOne;
                edituser.AddressLineTwo = model.AddressLineTwo;
                edituser.PostalCode = model.PostalCode; 
                edituser.HomePhone = model.HomePhone;
                edituser.MobilePhone = model.MobilePhone;
                edituser.EmergencyContactName = model.EmergencyContactName;
                edituser.EmergencyContactPhone = model.EmergencyContactPhone;
                edituser.RelationshipToEmergencyContact = model.RelationshipToEmergencyContact;
                edituser.FamilyDoctorName = model.FamilyDoctorName;


                //edituser.HealthCarePlan = model.HealthCarePlan;
                //edituser.Coverage = model.Coverage;
                //edituser.HealthID = model.HealthID;
                edituser.MedicalConditions = model.MedicalConditions;
               
                edituser.PastMedicalHistory = model.PastMedicalHistory;
                edituser.IsInMedicaion = model.IsInMedicaion;
                edituser.Medications = model.Medications;
                edituser.HasPastSurgery = model.HasPastSurgery;
                edituser.PastSurgeries = model.PastSurgeries;
                edituser.HasAllergy = model.HasAllergy;

                edituser.Allergies = model.Allergies;
                edituser.FamilyHistory = model.FamilyHistory;
                edituser.hasGeneticTest = model.hasGeneticTest;
                edituser.GeneticTest = model.GeneticTest;
                edituser.doYouSmoke = model.doYouSmoke;
                edituser.doYouIllegalDrugs = model.doYouIllegalDrugs;
                edituser.doYouConsumeAlcohol = model.doYouConsumeAlcohol;
                edituser.CovidDetails = model.CovidDetails;
            

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
