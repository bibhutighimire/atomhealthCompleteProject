using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class PastMedicalHistory
    {
        public Guid PastMedicalHistoryID { get; set; }
        public string PastMedicalHistoryName { get; set; }
        public bool isChecked { get; set; }
    }
}
