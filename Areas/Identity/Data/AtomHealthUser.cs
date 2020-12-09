using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtomHealth.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AtomHealthUser class
    public class AtomHealthUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

       [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Sex { get; set; }

    [PersonalData]
        [Column(TypeName = "nvarchar(10)")]
        public string Height { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(10)")]
        public string Weight { get; set; }

        [PersonalData]
        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string HealthCarePlan { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string HealthID { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyContactName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyContactPhone { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FamilyDoctorName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string MedicalConditions { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Medicines { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string PastSurgeries { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Allergies { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(256)")]
        public string FamilyHistory { get; set; }

        [PersonalData]
        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(500)")]
        public string Diseases { get; set; }




    }
}
