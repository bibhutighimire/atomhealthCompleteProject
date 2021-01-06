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
        [Required]
        [Column(TypeName = "varchar(100)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage ="Please enter characters only.")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage ="Please enter characters only.")]
        public string MiddleName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "varchar(100)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage ="Please enter characters only.")]
        public string LastName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Gender { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string MaritalStatus { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9]+[1,10]*$", ErrorMessage = "Please enter numbers only.")]
        public string Height { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9]+[1,10]*$", ErrorMessage = "Please enter numbers only.")]
        public string Weight { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }

    }
}
