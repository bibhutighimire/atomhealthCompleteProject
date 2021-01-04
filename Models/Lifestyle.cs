using AtomHealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Lifestyle
    {
        public Guid LifestyleID { get; set; }
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

        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
