using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class FamilyMedicalHistory
    {
        public Guid FamilyMedicalHistoryID { get; set; }
        public string FamilyMedicalHistoryName { get; set; }
        public bool isChecked { get; set; }
    }
}
