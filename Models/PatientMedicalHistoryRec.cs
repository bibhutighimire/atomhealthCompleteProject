using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class PatientMedicalHistoryRec
    {
        public Guid PatientMedicalHistoryRecID { get; set; }

        public string MedicalHistoryID { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
