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
using System.IO;
using System.Net.Mail;

namespace AtomHealth.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly UserManager<AtomHealthUser> _userManager;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly AtomHealthDBContext _context;
        //private readonly SignInManager<AtomHealthUser> _signInManager;
        private readonly ILogger<QRCodeController> _logger;

        public QRCodeController(ILogger<QRCodeController> logger, UserManager<AtomHealthUser> userManager, AtomHealthDBContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            //_signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string userid)
        {
            Random generator = new Random();
            string r = generator.Next(0, 1000000).ToString("D6");
            HttpContext.Session.SetString("RandomPasscode", r);

            string id = userid;
            HttpContext.Session.SetString("PatientID", id);

            var user = await _userManager.FindByIdAsync(userid);

            string to = user.Email;
            string subject = "QR Code access!";
            string body =
            $"Hello User!,{Environment.NewLine}" +
            $"{ Environment.NewLine}" +
                       $"We want to let you know that we received  request to view your Medical Record through QR Code Scan.{Environment.NewLine}" +
                         $"{ Environment.NewLine}" +
                               $"Your one time passcode is {r}.{Environment.NewLine}" +
                               $"{ Environment.NewLine}" +
                        $"ATOM HEALTH TEAM";

            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("atomhealth1@gmail.com", "Atom Health Team");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("atomhealth1@gmail.com", "Atomhealth@2020");
            smtp.Send(mm);

            return View();
        }
        
        //public IActionResult GeneratoRandomCodeView()
        //{
            
        //    Random generator = new Random();
        //    string r = generator.Next(0, 1000000).ToString("D6");

        //    HttpContext.Session.SetString("RandomPasscode", r);
        //    var email = HttpContext.Session.GetString("EmailAddress");


            
        //    string to = email;
        //    string subject = "QR Code access!";
        //    string body =
        //    $"Hello User!,{Environment.NewLine}" +
        //    $"{ Environment.NewLine}" +
        //               $"We want to let you know that we received  request to view your Medical Record through QR Code Scan.{Environment.NewLine}" +
        //                 $"{ Environment.NewLine}" +
        //                       $"Your one time passcode is {r}.{Environment.NewLine}" +
        //                       $"{ Environment.NewLine}" +
        //                $"ATOM HEALTH TEAM";

        //    MailMessage mm = new MailMessage();
        //    mm.To.Add(to);
        //    mm.Subject = subject;
        //    mm.Body = body;
        //    mm.From = new MailAddress("atomhealth1@gmail.com", "Atom Health Team");
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.Credentials = new System.Net.NetworkCredential("atomhealth1@gmail.com", "Atomhealth@2020");
        //    smtp.Send(mm);

        //    return View();
        //}

   
        public async Task<IActionResult> GenerateRandomCodeViewWithCheck(string DoctorEnteredCode)
        {
           

            string useridval = HttpContext.Session.GetString("PatientID");
            var MachineGeneratedCode = HttpContext.Session.GetString("RandomPasscode");
            if(DoctorEnteredCode==MachineGeneratedCode)
            {
                return RedirectToAction("Details", new { userid = useridval });
               
            }
        
            return View();
        }
        public async Task<IActionResult> Download()
        {
            var path = @"C:\Users\18705\Downloads\Banner.png";
            var memory = new MemoryStream();
            using(var stream=new FileStream(path,FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(path));
        }

        public Dictionary<string,string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png" }
            };
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
