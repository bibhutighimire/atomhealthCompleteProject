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
    public class ApplicationUser
    {
        public Guid ApplicationUserID { get; set; }

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
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }

    }
}
