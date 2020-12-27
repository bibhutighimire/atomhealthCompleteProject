using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class PastMedicalHistoryRec
    {
        public Guid PastMedicalHistoryRecID { get; set; }

        public string PastMedicalHistoryID { get; set; }
        public PastMedicalHistory PastMedicalHistory { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
