using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class CurrentMedicalConditionRec
    {
        public Guid CurrentMedicalConditionRecID { get; set; }

        public string CurrentMedicalConditionID { get; set; }
        public CurrentMedicalCondition CurrentMedicalCondition { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
