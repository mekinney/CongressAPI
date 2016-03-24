using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Amendment
    {
        public string amendment_id { get; set; }
        public string amendment_type { get; set; }
        public Amendment amends_amendment { get; set; }
        public Bill amends_bill { get; set; }
        public string amends_bill_id { get; set; }
        public string chamber { get; set; }
        public int? congress { get; set; }
        public string description { get; set; }
        public int? house_number { get; set; }
        public DateTime? introduced_on { get; set; }
        public DateTime? last_action_at { get; set; }
        public int? number { get; set; }
        public string purpose { get; set; }
        public string sponsor_id { get; set; }
        public string sponsor_type { get; set; }
        public AmendmentSponsor sponsor { get; set; }
    }

    // This is a bit of a compromise, because an amendment sponsor can be either a person or committee
    // Here we're creating a new class that adds the committee fields to a Legislator class to create the required composite.
    
    public class AmendmentSponsor : Legislator
    {
        // public string chamber { get; set; }      // TODO: Do committee's have a specific chamber?
        public string committee_id { get; set; }
        public string name { get; set; }
        // public string office { get; set; }       // TODO: Do committee's have a specific office?
        // public string phone { get; set; }        // TODO: Do committee's have a specific phone?
        public bool? subcommittee { get; set; }
    }

}
