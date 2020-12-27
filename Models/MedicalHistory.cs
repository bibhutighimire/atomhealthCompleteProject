using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class MedicalHistory
    {
        public Guid MedicalHistoryID { get; set; }
        public string MedicalHistoryName { get; set; }
        public bool isChecked { get; set; }
    }
}
