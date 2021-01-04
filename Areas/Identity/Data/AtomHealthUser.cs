using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtomHealth.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AtomHealthUser class
    public class AtomHealthUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string BloodType { get; set; }
        [PersonalData]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime? DOB { get; set; }

        public Address Address { get; set; }

        public Phonenumbers Phonenumbers { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Lifestyle Lifestyle { get; set; }


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
        [Column(TypeName = "nvarchar(1000)")]
        public string ImmunizationRecord { get; set; }
        [NotMapped]
        public int[] ImmunizationID { get; set; }
        [NotMapped]
        public int[] MedicalHistoryID { get; set; }
        [NotMapped]
        public int[] CurrentMedicalConditionID { get; set; }

        [NotMapped]
        public int[] PastMedicalHistoryID { get; set; }

        [NotMapped]
        public int[] FamilyMedicalHistoryID { get; set; }
      
        [NotMapped]
        public int[] CovidHistoryID { get; set; }

    }
}
