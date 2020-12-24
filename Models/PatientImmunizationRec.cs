using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class PatientImmunizationRec
    {
        public Guid PatientImmunizationRecID { get; set; }

        public string ImmunizationID { get; set; }
        public Immunization Immunization { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
