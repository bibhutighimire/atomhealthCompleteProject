using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Immunization
    {
        public Guid ImmunizationID { get; set; }
        public string ImmunizationName { get; set; }
        public bool isChecked { get; set; }
    }
}
