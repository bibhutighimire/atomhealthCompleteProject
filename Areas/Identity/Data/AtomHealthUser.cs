﻿using System;
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
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string MiddleName { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(50)")]
        public string Gender { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string MaritalStatus { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int? Height { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int? Weight { get; set; }
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string BloodType { get; set; }
        [PersonalData]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime? DOB { get; set; }

        public Address Address { get; set; }

      

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string HomePhone { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string MobilePhone { get; set; }



        [PersonalData]
        [Column(TypeName = "varchar(200)")]
        public string EmergencyContactName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string EmergencyContactPhone { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string RelationshipToEmergencyContact { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(200)")]
        public string FamilyDoctorName { get; set; }

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
        [Column(TypeName = "varchar(20)")]
        public string doYouSmoke { get; set; }
        [PersonalData]
        [Column(TypeName = "varchar(20)")]
        public string doYouIllegalDrugs { get; set; }
        [PersonalData]
        [Column(TypeName = "varchar(20)")]
        public string doYouConsumeAlcohol { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(200)")]
        public string Diet { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(200)")]
        public string Exercise { get; set; }

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
