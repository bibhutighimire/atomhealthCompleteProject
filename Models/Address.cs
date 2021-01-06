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
    public class Address
    {
        public Guid AddressID { get; set; }
        [PersonalData]
        [Column(TypeName = "varchar(100)")]

        public string Country { get; set; }

        [PersonalData]

        [Column(TypeName = "varchar(100)")]
        public string Province { get; set; }

        public PatientProvinceRec PatientProvinceRec { get; set; }

        [PersonalData]
  
        [Column(TypeName = "varchar(100)")]
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
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
