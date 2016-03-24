using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Upcoming_bill
    {
        public string legislative_day { get; set; }
        public string range { get; set; }
        public string chamber { get; set; }
        public string bill_id { get; set; }
        public string scheduled_at { get; set; }
        public string context { get; set; }
        public int congress { get; set; }
        public string source_type { get; set; }
        public string url { get; set; }
        public Bill bill { get; set; }

    }
}
