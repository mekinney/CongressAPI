using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{

    public class Vote
    {
        public Bill bill { get; set; }
        public string bill_id { get; set; }
        public Breakdown breakdown { get; set; }
        public string chamber { get; set; }
        public int congress { get; set; }
        public int number { get; set; }
        public string question { get; set; }
        public string required { get; set; }
        public string result { get; set; }
        public string roll_id { get; set; }
        public string roll_type { get; set; }
        public string vote_type { get; set; }
        public string voted_at { get; set; }
        public Dictionary<string,string> voter_ids { get; set; }
        public Dictionary<string,Voter> voters { get; set; }
        public int year { get; set; }
    }

    public class Breakdown
    {
        public Total total { get; set; }
    }

    public class Total
    {
        public int Nay { get; set; }
        public int Yea { get; set; }
        public int NotVoting { get; set; }
        public int Present { get; set; }
    }

    public class Voter  // Replace with Legislator?
    {
        public string bioguide_id { get; set; }
        public string birthday { get; set; }
        public string chamber { get; set; }
        public object contact_form { get; set; }
        public string crp_id { get; set; }
        public int district { get; set; }
        public string facebook_id { get; set; }
        public string fax { get; set; }
        public List<string> fec_ids { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public string govtrack_id { get; set; }
        public bool in_office { get; set; }
        public string last_name { get; set; }
        public object leadership_role { get; set; }
        public object middle_name { get; set; }
        public object name_suffix { get; set; }
        public object nickname { get; set; }
        public string oc_email { get; set; }
        public string ocd_id { get; set; }
        public string office { get; set; }
        public string party { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string state_name { get; set; }
        public string term_end { get; set; }
        public string term_start { get; set; }
        public string thomas_id { get; set; }
        public string title { get; set; }
        public string twitter_id { get; set; }
        public string website { get; set; }
    }

    public class VoteDistinctComparer : IEqualityComparer<Vote>
    {
        public bool Equals(Vote x, Vote y)
        {
            return x.roll_id == y.roll_id;
        }

        public int GetHashCode(Vote obj)
        {
            return obj.roll_id.GetHashCode();
        }
    }

}
