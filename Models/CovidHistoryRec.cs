using AtomHealth.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class CovidHistoryRec
    {
        public Guid CovidHistoryRecID { get; set; }

        public string CovidHistoryID { get; set; }
        public CovidHistory CovidHistory { get; set; }
        public string AtomHealthUserID { get; set; }
        public AtomHealthUser AtomHealthUser { get; set; }
    }
}
