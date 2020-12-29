using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class PatientProvinceRec
    {
        public Guid PatientProvinceRecID { get; set; }

        public string ProvinceID { get; set; }
        public Province Province { get; set; }

        public string CountryID { get; set; }
        public Country Country { get; set; }

        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
