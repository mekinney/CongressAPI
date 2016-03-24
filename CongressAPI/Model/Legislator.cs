using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{

    public class Legislator  // Listed in order of the API documentation.
    {
        public bool? in_office { get; set; }
        public string party { get; set; }
        public string gender { get; set; }
        public string state { get; set; }
        public string state_name { get; set; }
        public int? district { get; set; }
        public string state_rank { get; set; }
        public string title { get; set; }
        public string chamber { get; set; }
        public int? senate_class { get; set; }
        public DateTime? birthday { get; set; }
        public DateTime? term_start { get; set; }
        public DateTime? term_end { get; set; }

        // Identifiers
        public string bioguide_id { get; set; }
        public string ocd_id { get; set; }
        public string thomas_id { get; set; }
        public string govtrack_id { get; set; }
        public string votesmart_id { get; set; }
        public string crp_id { get; set; }
        public string lis_id { get; set; }
        public int? icpsr_id { get; set; }
        public List<string> fec_ids { get; set; }

        // Names
        public string first_name { get; set; }
        public string nickname { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string name_suffix { get; set; }
        public List<string> aliases { get; set; }

        public List<OtherName> other_names { get; set; }  // TODO: Verify aliases in documentation.

        // Contact info
        public string phone { get; set; }
        public string fax { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string contact_form { get; set; }

        // Social Media
        public string twitter_id { get; set; }
        public string youtube_id { get; set; }
        public string facebook_id { get; set; }
        public List<string> campaign_twitter_ids { get; set; }

        public List<Term> terms { get; set; }

        // In json response but not in documentation

        public string leadership_role { get; set; }
        public string oc_email { get; set; }

    }

    public class Term
    {
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public string state { get; set; }
        public string party { get; set; }
        public int? classnum { get; set; }   // TODO: class in API - reserved word in C#
        public string title { get; set; }
        public string chamber { get; set; }
    }

    public class OtherName
    {
        public string last { get; set; }
    }

    public class LegislatorDistinctComparer : IEqualityComparer<Legislator>
    {
        public bool Equals(Legislator x, Legislator y)
        {
            return x.bioguide_id == y.bioguide_id;
        }

        public int GetHashCode(Legislator obj)
        {
            return obj.bioguide_id.GetHashCode();
        }
    }
}
