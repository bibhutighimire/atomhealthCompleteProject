using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class CurrentMedicalCondition
    {
        public Guid CurrentMedicalConditionID { get; set; }
        public string CurrentMedicalConditionName { get; set; }
        public bool isChecked { get; set; }
    }
}
