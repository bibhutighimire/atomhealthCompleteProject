using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class CovidHistory
    {
        public Guid CovidHistoryID { get; set; }
        public string CovidHistoryName { get; set; }
        public bool isChecked { get; set; }
    }
}
