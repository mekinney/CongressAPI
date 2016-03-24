using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Nomination
    {
        public string nomination_id { get; set; }
        public int congress { get; set; }
        public string number { get; set; }
        public List<Nominee> nominees { get; set; }
        public string organization { get; set; }
        public string received_on { get; set; }
        public List<string> committee_ids { get; set; }
        public List<NominationAction> actions { get; set; }
        public NominationAction last_action { get; set; }
        public string last_action_at { get; set; }
    }

    public class Nominee
    {
        public string name { get; set; }
        public string position { get; set; }
        public string state { get; set; }
    }

    public class NominationAction
    {
        public string acted_at { get; set; }
        public string location { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }


}
