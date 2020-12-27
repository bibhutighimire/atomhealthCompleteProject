using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class ListOfAllTable
    {
        public AtomHealthUser ListOfAtomHealthUser { get; set; }
        public MedicalCoverage ListOfMedicalCoverage { get; set; }

        public Immunization ListOfImmunization { get; set; }

        public PatientImmunizationRec ListOfPatientImmunizationRec { get; set; }
        public Employee ListOfEmployee { get; set; }

    }
}
