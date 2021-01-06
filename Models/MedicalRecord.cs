using AtomHealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class MedicalRecord
    {
        public Guid MedicalRecordID { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string MedicalConditions { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string PastMedicalHistoryDetails { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(20)")]
        public string IsInMedicaion { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string Medications { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(20)")]
        public string HasPastSurgery { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string PastSurgeries { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(20)")]
        public string HasAllergy { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string Allergies { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string FamilyHistory { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(20)")]
        public string hasGeneticTest { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string GeneticTest { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(500)")]
        public string CovidDetails { get; set; }

        [PersonalData]
       
        [Column(TypeName = "varchar(100)")]      
        public string BloodType { get; set; }

       
        [PersonalData]
        [Column(TypeName = "nvarchar(1000)")]
        public string ImmunizationRecord { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
