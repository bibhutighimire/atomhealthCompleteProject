using AtomHealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class MedicalCoverage
    {
        public Guid MedicalCoverageID { get; set; }
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string HasMedicalCoverage { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string HealthCarePlan { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string Coverage { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string HealthID { get; set; }

        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
