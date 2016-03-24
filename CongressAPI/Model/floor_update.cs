using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Floor_update
    {
        public string timestamp { get; set; }
        public string chamber { get; set; }
        public string update { get; set; }
        public int congress { get; set; }
        public string category { get; set; }
        public int year { get; set; }
        public string legislative_day { get; set; }
        public List<string> bill_ids { get; set; }
        public List<string> roll_ids { get; set; }
        public List<string> legislator_ids { get; set; }

    }
}
