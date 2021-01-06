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
    public class Phonenumbers
    {
        public Guid PhonenumbersID { get; set; }
        [PersonalData]
        
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid")]
        public string HomePhone { get; set; }

        [PersonalData]
        [Required]
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
        [Column(TypeName = "varchar(200)")]
        public string FamilyDoctorName { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
