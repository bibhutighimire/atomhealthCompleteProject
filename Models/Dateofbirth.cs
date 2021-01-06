using AtomHealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Dateofbirth
    {
        public Guid DateofbirthID { get; set; }
        [PersonalData]
      
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public string DOB { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
