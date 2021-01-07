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
using Microsoft.EntityFrameworkCore;

namespace AtomHealth.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly UserManager<AtomHealthUser> _userManager;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly AtomHealthDBContext _context;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly ILogger<MedicalHistoryController> _logger;

        public QRCodeController(ILogger<QRCodeController> logger, UserManager<AtomHealthUser> userManager, AtomHealthDBContext context)
        {
           // _logger = logger;
            _userManager = userManager;
            _context = context;
            //_signInManager = signInManager;
        }

        public IActionResult Details(string userid)
        {
            ViewBag.listOfMedicalCoverage = _context.MedicalCoverage.Where(x => x.AtomHealthUserID == userid).ToList();


            List<Immunization> ListOfImmunization = _context.Immunization.ToList();


            ViewBag.ListOfPatientImmunizationRecn = _context.PatientImmunizationRec.Where(x => x.AtomHealthUserID == userid).Select(p => p.ImmunizationID).Distinct().ToList();

            ViewBag.listOfPatientMedicalHistory = _context.PatientMedicalHistoryRec.Where(x => x.AtomHealthUserID == userid).Select(p => p.MedicalHistoryID).Distinct().ToList();

            ViewBag.ListOfCovidHistoryRec = _context.CovidHistoryRec.Where(x => x.AtomHealthUserID == userid).Select(p => p.CovidHistoryID).Distinct().ToList();

            ViewBag.ListOfFamilyMedicalHistoryRec = _context.FamilyMedicalHistoryRec.Where(x => x.AtomHealthUserID == userid).Select(p => p.FamilyMedicalHistoryID).Distinct().ToList();

            ViewBag.ListOfCurrentMedicalConditionRec = _context.CurrentMedicalConditionRec.Where(x => x.AtomHealthUserID == userid).Select(p => p.CurrentMedicalConditionID).Distinct().ToList();

            ViewBag.ListOfPastMedicalHistoryRec = _context.PastMedicalHistoryRec.Where(x => x.AtomHealthUserID == userid).Select(p => p.PastMedicalHistoryID).Distinct().ToList();
            var taretUser = _context.ApplicationUser.Where(x => x.AtomHealthUserID == userid).FirstOrDefault();
            var AddressTarget = _userManager.Users.Include(u => u.Phonenumbers).Include(V => V.Address).Include(w => w.Lifestyle).Include(x => x.ApplicationUser).Include(x => x.Dateofbirth).Include(x => x.MedicalRecord).ToList();
            var JoinedTarget = AddressTarget.Where(x => x.Id == taretUser.AtomHealthUserID).FirstOrDefault();

            return View(JoinedTarget);
        }
    }
}
