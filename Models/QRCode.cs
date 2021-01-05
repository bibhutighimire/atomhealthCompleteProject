using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class QRCode
    {
        public Guid QRCodeID { get; set; }
        public string QRCodeFile { get; set; }
        public Address Address { get; set; }
        public Phonenumbers Phonenumbers { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Lifestyle Lifestyle { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
