using AtomHealth.Areas.Identity.Data;
using AtomHealth.Data;
using AtomHealth.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;


using Microsoft.AspNetCore.Http;

namespace AtomHealth.Controllers
{
    public class MedicalHistoryController : Controller
    {
        private readonly UserManager<AtomHealthUser> _userManager;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly AtomHealthDBContext _context;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly ILogger<MedicalHistoryController> _logger;

        public MedicalHistoryController(ILogger<MedicalHistoryController> logger, UserManager<AtomHealthUser> userManager, AtomHealthDBContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            //_signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MedicalHistory medicalHistory)
        {
            _context.MedicalHistory.Add(medicalHistory);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult CurrentMedicalCondition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CurrentMedicalCondition(CurrentMedicalCondition currentMedicalCondition)
        {
            _context.CurrentMedicalCondition.Add(currentMedicalCondition);
            _context.SaveChanges();
            return RedirectToAction("CurrentMedicalCondition");
        }

        [HttpGet]
        public IActionResult PastMedicalHistory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PastMedicalHistory(PastMedicalHistory pastMedicalHistory)
        {
            _context.PastMedicalHistory.Add(pastMedicalHistory);
            _context.SaveChanges();
            return RedirectToAction("PastMedicalHistory");
        }

        [HttpGet]
        public IActionResult CovidHistory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CovidHistory(CovidHistory covidHistory)
        {
            _context.CovidHistory.Add(covidHistory);
            _context.SaveChanges();
            return RedirectToAction("CovidHistory");
        }

        [HttpGet]
        public IActionResult FamilyMedicalHistory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FamilyMedicalHistory(FamilyMedicalHistory familyMedicalHistory)
        {
            _context.FamilyMedicalHistory.Add(familyMedicalHistory);
            _context.SaveChanges();
            return RedirectToAction("FamilyMedicalHistory");
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();
            return RedirectToAction("AddCountry");
        }

        [HttpGet]
        public IActionResult AddProvince()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProvince(Province province)
        {
            _context.Province.Add(province);
            _context.SaveChanges();
            return RedirectToAction("AddProvince");
        }

        [HttpGet]
        public IActionResult AddCountryAndState()
        {
            ViewBag.listOfCountry = _context.Country.ToList();
            ViewBag.listOfProvince = _context.Province.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddCountryAndState(PatientProvinceRec patientProvinceRec)
        {
            _context.PatientProvinceRec.Add(patientProvinceRec);
            _context.SaveChanges();
            return RedirectToAction("AddCountryAndState");
        }


    }
}
