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
        public QRCode QRCode { get; set; }
        public Address Address { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    
        public Dateofbirth Dateofbirth { get; set; }

        public Phonenumbers Phonenumbers { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Lifestyle Lifestyle { get; set; }

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
