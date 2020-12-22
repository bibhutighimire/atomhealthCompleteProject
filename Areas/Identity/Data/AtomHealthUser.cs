﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Gender { get; set; }

    [PersonalData]
        [Column(TypeName = "int")]
        public int Height { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int Weight { get; set; }

        [PersonalData]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime? DOB { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Province { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string AddressLineOne { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string AddressLineTwo { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string PostalCode { get; set; }

        [PersonalData]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string HomePhone { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string MobilePhone { get; set; }

        

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string EmergencyContactName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string EmergencyContactPhone { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string RelationshipToEmergencyContact { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string FamilyDoctorName { get; set; }



        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string HealthCarePlan { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string Coverage { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string HealthID { get; set; }

       
        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string MedicalConditions { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string PastMedicalHistory { get; set; }

        [PersonalData]
        public bool IsInMedicaion { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string Medications { get; set; }

        [PersonalData]
        public bool HasPastSurgery { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string PastSurgeries { get; set; }

        [PersonalData]
        public bool HasAllergy { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string Allergies { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string FamilyHistory { get; set; }

        public bool hasGeneticTest { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string GeneticTest { get; set; }

        public bool doYouSmoke { get; set; }
        public bool doYouIllegalDrugs { get; set; }
        public bool doYouConsumeAlcohol { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(500)")]
        public string CovidDetails { get; set; }




    }
}
