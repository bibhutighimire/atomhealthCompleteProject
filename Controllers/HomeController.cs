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
using Microsoft.AspNetCore.Authorization;
using static AtomHealth.Areas.Identity.Pages.Account.ExternalLoginModel;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using AtomHealth.Data;
using Microsoft.AspNetCore.Http;

namespace AtomHealth.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly UserManager<AtomHealthUser> _userManager;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
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

        public IActionResult DeleteCoverage(Guid id)
        {
            var user =  _context.MedicalCoverage.Where(x => x.MedicalCoverageID == id).FirstOrDefault();
            
            _context.MedicalCoverage.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("MedicalCoverageList");
        }

        [HttpGet]
        public async Task<IActionResult> MedicalCoverageAdd()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.id = user.Id;


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MedicalCoverageAddNew(MedicalCoverage medicalCoverage)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.id = user.Id;
            MedicalCoverage mc = new MedicalCoverage();
            mc.AtomHealthUserID = user.Id;
            mc.HealthCarePlan = medicalCoverage.HealthCarePlan;
            mc.Coverage = medicalCoverage.Coverage;
            mc.HealthID = medicalCoverage.HealthID;
            _context.MedicalCoverage.Add(mc);
            _context.SaveChanges();

            return RedirectToAction("MedicalCoverageList");
        }
        [HttpGet]
        public async Task<IActionResult> MedicalCoverageList()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.id = user.Id;


            return View(_context.MedicalCoverage.Where(x=>x.AtomHealthUserID==user.Id).ToList());
        }
        [HttpGet]
        public IActionResult AddImmunization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImmunization(Immunization immunization)
        {
            _context.Immunization.Add(immunization);
            _context.SaveChanges();
             return View();
        }
       
        public async Task<IActionResult> UserProfile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.id = user.Id;
            ViewBag.listOfMedicalCoverage = _context.MedicalCoverage.Where(x => x.AtomHealthUserID == user.Id).ToList();

            
            List<Immunization> ListOfImmunization = _context.Immunization.ToList();

            //ViewBag.ListOfPatientImmunizationRecn = _context.PatientImmunizationRec.Where(x => x.AtomHealthUserID == user.Id).Select(n => new {n.ImmunizationID}).ToList();

            ViewBag.ListOfPatientImmunizationRecn = _context.PatientImmunizationRec.Where(x => x.AtomHealthUserID == user.Id).ToList();

            ViewBag.listOfPatientMedicalHistory = _context.PatientMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();

            ViewBag.ListOfCovidHistoryRec = _context.CovidHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();

            ViewBag.ListOfFamilyMedicalHistoryRec = _context.FamilyMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();

            ViewBag.ListOfCurrentMedicalConditionRec = _context.CurrentMedicalConditionRec.Where(x => x.AtomHealthUserID == user.Id).ToList();

            ViewBag.ListOfPastMedicalHistoryRec = _context.PastMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();

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
            ViewBag.immunization = _context.Immunization.ToList();
            ViewBag.medicalhistory = _context.MedicalHistory.ToList();
            ViewBag.currentmedicalconditions = _context.CurrentMedicalCondition.ToList();
            ViewBag.pastmedicalhistory = _context.PastMedicalHistory.ToList();
            ViewBag.familyMedicalHistory = _context.FamilyMedicalHistory.ToList();
            ViewBag.CovidHistory = _context.CovidHistory.ToList();
            return View(user);
           
        }


        [HttpPost]
        public async Task<IActionResult> EditUserProfile(AtomHealthUser model,IFormCollection formval, string key, string fallback)
        {
            var edituser = await _userManager.FindByIdAsync(model.Id);
            
                string ImmunizationID = formval["ImmunizationID"];
            if (ImmunizationID != null)
            {
                string[] c = ImmunizationID.Split(",");
            int countImmu = c.Count();
            
                for (int i = 0; i <= countImmu - 1; i++)
                {
                    PatientImmunizationRec prec = new PatientImmunizationRec();
                    prec.AtomHealthUserID = edituser.Id;
                    prec.ImmunizationID = c[i];
                    _context.PatientImmunizationRec.Add(prec);
                    _context.SaveChanges();
                }
            }
            string FamilyMedicalHistoryID = formval["FamilyMedicalHistoryID"];
            if (FamilyMedicalHistoryID != null)
            {
                string[] mh = FamilyMedicalHistoryID.Split(",");
            int countMh = mh.Count();
            
                for (int i = 0; i <= countMh - 1; i++)
                {
                    FamilyMedicalHistoryRec mhr = new FamilyMedicalHistoryRec();
                    mhr.AtomHealthUserID = edituser.Id;
                    mhr.FamilyMedicalHistoryID = mh[i];
                    _context.FamilyMedicalHistoryRec.Add(mhr);
                    _context.SaveChanges();
                }
            }

            string CovidHistoryID = formval["CovidHistoryID"];
            if (CovidHistoryID != null)
            {
                string[] ch = CovidHistoryID.Split(",");
            int countch = ch.Count();
            
                for (int i = 0; i <= countch - 1; i++)
                {
                    CovidHistoryRec mhr = new CovidHistoryRec();
                    mhr.AtomHealthUserID = edituser.Id;
                    mhr.CovidHistoryID = ch[i];
                    _context.CovidHistoryRec.Add(mhr);
                    _context.SaveChanges();
                }
            }

            string PastMedicalHistoryID = formval["PastMedicalHistoryID"];
            if (PastMedicalHistoryID != null)
            {
                string[] pmh = PastMedicalHistoryID.Split(",");
            int countpmh = pmh.Count();
            
                for (int i = 0; i <= countpmh - 1; i++)
                {
                    PastMedicalHistoryRec mhr = new PastMedicalHistoryRec();
                    mhr.AtomHealthUserID = edituser.Id;
                    mhr.PastMedicalHistoryID = pmh[i];
                    _context.PastMedicalHistoryRec.Add(mhr);
                    _context.SaveChanges();
                }
            }

            string CurrentMedicalConditionID = formval["CurrentMedicalConditionID"];
            if (CurrentMedicalConditionID != null)
            {
                string[] cmc = CurrentMedicalConditionID.Split(",");
            int countcmc = cmc.Count();
            
                for (int i = 0; i <= countcmc - 1; i++)
                {
                    CurrentMedicalConditionRec mhr = new CurrentMedicalConditionRec();
                    mhr.AtomHealthUserID = edituser.Id;
                    mhr.CurrentMedicalConditionID = cmc[i];
                    _context.CurrentMedicalConditionRec.Add(mhr);
                    _context.SaveChanges();
                }
            }


            edituser.FirstName = model.FirstName;
                edituser.MiddleName = model.MiddleName;
                edituser.LastName = model.LastName;
                edituser.Gender = model.Gender;
                edituser.MaritalStatus = model.MaritalStatus;
                edituser.Height = model.Height;
                edituser.Weight = model.Weight;
                edituser.BloodType = model.BloodType;
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
               
                //edituser.HealthCarePlan = model.HealthCarePlan;
                //edituser.Coverage = model.Coverage;
                //edituser.HealthID = model.HealthID;
                edituser.MedicalConditions = model.MedicalConditions;               
                edituser.PastMedicalHistoryDetails = model.PastMedicalHistoryDetails;
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
                edituser.Diet = model.Diet;
                edituser.Exercise = model.Exercise;
                edituser.CovidDetails = model.CovidDetails;
                edituser.ImmunizationRecord = model.ImmunizationRecord;
                edituser.ImmunizationID = model.ImmunizationID;

                var result = await _userManager.UpdateAsync(edituser);
                //PatientImmunizationRec p = new PatientImmunizationRec();
                //Immunization im= new Immunization();

                //im.ImmunizationID = immu.ImmunizationID;
                //im.ImmunizationID = immu.ImmunizationID;
                //_context.Immunization.Add(im);
                _context.SaveChanges();


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
