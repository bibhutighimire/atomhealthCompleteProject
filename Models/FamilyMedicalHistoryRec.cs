using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class FamilyMedicalHistoryRec
    {
        public Guid FamilyMedicalHistoryRecID { get; set; }

        public string FamilyMedicalHistoryID { get; set; }
        public FamilyMedicalHistory FamilyMedicalHistory { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
