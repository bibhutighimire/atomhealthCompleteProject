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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            //initializing address table
            var checkAddressValue = _context.Address.Where(x => x.AtomHealthUserID == user.Id).FirstOrDefault();
            if(checkAddressValue==null)
            {
                Address addr = new Address();
                addr.AtomHealthUserID = user.Id;
                _context.Address.Add(addr);
                _context.SaveChanges();
            }
            //initializing phonenumber table
            var checkPhoneValue = _context.Phonenumbers.Where(x => x.AtomHealthUserID == user.Id).FirstOrDefault();
            if (checkPhoneValue == null)
            {
                Phonenumbers phn = new Phonenumbers();
                phn.AtomHealthUserID = user.Id;
                _context.Phonenumbers.Add(phn);
                _context.SaveChanges();
            }


            ViewBag.listOfMedicalCoverage = _context.MedicalCoverage.Where(x => x.AtomHealthUserID == user.Id).ToList();

            
            List<Immunization> ListOfImmunization = _context.Immunization.ToList();


            ViewBag.ListOfPatientImmunizationRecn = _context.PatientImmunizationRec.Where(x => x.AtomHealthUserID == user.Id).Select(p => p.ImmunizationID).Distinct().ToList();

            ViewBag.listOfPatientMedicalHistory = _context.PatientMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).Select(p => p.MedicalHistoryID).Distinct().ToList();

            ViewBag.ListOfCovidHistoryRec = _context.CovidHistoryRec.Where(x => x.AtomHealthUserID == user.Id).Select(p => p.CovidHistoryID).Distinct().ToList();

            ViewBag.ListOfFamilyMedicalHistoryRec = _context.FamilyMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).Select(p => p.FamilyMedicalHistoryID).Distinct().ToList();

            ViewBag.ListOfCurrentMedicalConditionRec = _context.CurrentMedicalConditionRec.Where(x => x.AtomHealthUserID == user.Id).Select(p => p.CurrentMedicalConditionID).Distinct().ToList();

            ViewBag.ListOfPastMedicalHistoryRec = _context.PastMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).Select(p => p.PastMedicalHistoryID).Distinct().ToList();

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
            var AddressTarget = _userManager.Users.Include(u => u.Phonenumbers).Include(V=>V.Address).ToList();
            var JoinedTarget = AddressTarget.Where(x => x.Id == user.Id).FirstOrDefault();
           
            //var immunizationDelete = _context.PatientImmunizationRec.Where(x => x.AtomHealthUserID == user.Id).ToList();
            //_context.PatientImmunizationRec.RemoveRange(immunizationDelete);
            //_context.SaveChanges();

            //var CovidHistoryRecDelete = _context.CovidHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();
            //_context.CovidHistoryRec.RemoveRange(CovidHistoryRecDelete);
            //_context.SaveChanges();

            //var FamilyMedicalHistoryRecDelete = _context.FamilyMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();
            //_context.FamilyMedicalHistoryRec.RemoveRange(FamilyMedicalHistoryRecDelete);
            //_context.SaveChanges();

            //var PastMedicalHistoryRecDelete = _context.PastMedicalHistoryRec.Where(x => x.AtomHealthUserID == user.Id).ToList();
            //_context.PastMedicalHistoryRec.RemoveRange(PastMedicalHistoryRecDelete);
            //_context.SaveChanges();

            //var CurrentMedicalConditionRecDelete = _context.CurrentMedicalConditionRec.Where(x => x.AtomHealthUserID == user.Id).ToList();
            //_context.CurrentMedicalConditionRec.RemoveRange(CurrentMedicalConditionRecDelete);
            //_context.SaveChanges();

            ViewBag.listOfCountry = _context.Country.ToList();
            ViewBag.listOfProvince = _context.Province.ToList();
            ViewBag.immunization = _context.Immunization.ToList();
            ViewBag.medicalhistory = _context.MedicalHistory.ToList();
            ViewBag.currentmedicalconditions = _context.CurrentMedicalCondition.ToList();
            ViewBag.pastmedicalhistory = _context.PastMedicalHistory.ToList();
            ViewBag.familyMedicalHistory = _context.FamilyMedicalHistory.ToList();
            ViewBag.CovidHistory = _context.CovidHistory.ToList();
            return View(JoinedTarget);
           
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
            //updating address table
            var addressTarget = _context.Address.Where(x => x.AtomHealthUserID == edituser.Id).FirstOrDefault();
            string Country = formval["Address.Country"];
            string Province = formval["Address.Province"];
            string City = formval["Address.City"];
            string AddressLineOne = formval["Address.AddressLineOne"];
            string AddressLineTwo = formval["Address.AddressLineTwo"];
            string PostalCode = formval["Address.PostalCode"];


            addressTarget.Country = Country;
            addressTarget.Province = Province;
            addressTarget.City = City;
            addressTarget.AddressLineOne = AddressLineOne;
            addressTarget.AddressLineTwo = AddressLineTwo;
            addressTarget.PostalCode = PostalCode;
                _context.Update(addressTarget);
                _context.SaveChanges();


            //updating phone number table
            var PhoneTarget = _context.Phonenumbers.Where(x => x.AtomHealthUserID == edituser.Id).FirstOrDefault();
            string HomePhone = formval["Phonenumbers.HomePhone"];
            string MobilePhone = formval["Phonenumbers.MobilePhone"];
            string EmergencyContactName = formval["Phonenumbers.EmergencyContactName"];
            string EmergencyContactPhone = formval["Phonenumbers.EmergencyContactPhone"];
            string RelationshipToEmergencyContact = formval["Phonenumbers.RelationshipToEmergencyContact"];
            string FamilyDoctorName = formval["Phonenumbers.FamilyDoctorName"];
           


            PhoneTarget.HomePhone = HomePhone;
            PhoneTarget.MobilePhone = MobilePhone;
           
            PhoneTarget.EmergencyContactName = EmergencyContactName;
            PhoneTarget.EmergencyContactPhone = EmergencyContactPhone;
            PhoneTarget.FamilyDoctorName = FamilyDoctorName;
            _context.Update(PhoneTarget);
            _context.SaveChanges();
           
            
            edituser.FirstName = model.FirstName;
                edituser.MiddleName = model.MiddleName;
                edituser.LastName = model.LastName;
                edituser.Gender = model.Gender;
                edituser.MaritalStatus = model.MaritalStatus;
                edituser.Height = model.Height;
                edituser.Weight = model.Weight;
                edituser.BloodType = model.BloodType;
                edituser.DOB = model.DOB;
                
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
        public IActionResult GetStateList(string countryName)
        {
            ViewBag.listOfProvince = _context.PatientProvinceRec.Where(x => x.CountryID == countryName).ToList();
            //ViewBag.ProvinceList = new SelectList(listOfProvince, "ProvinceID", "ProvinceName");
            return PartialView("DisplayProvinces");
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
