using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{

    // This class contains all the properties for both committee's and subcommittee's.
    // TODO: Can a committee be both?  Is there hierarchy or is it only one deep?

    public class Committee
    {
        public string chamber { get; set; }
        public string committee_id { get; set; }
        public List<string> member_ids { get; set; }
        public List<Member> members { get; set; }
        public string name { get; set; }
        public ParentCommittee parent_committee { get; set; }
        public string parent_committee_id { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public bool subcommittee { get; set; }
        public List<Subcommittee> subcommittees { get; set; }
        public string url { get; set; }
    }

    public class Member
    {
        public string side { get; set; }
        public int rank { get; set; }
        public string title { get; set; }
        public Legislator legislator { get; set; }
    }

    public class ParentCommittee
    {
        public string committee_id { get; set; }
        public string name { get; set; }
        public string chamber { get; set; }
        public string website { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public string house_committee_id { get; set; }  // Verify - Not in API Documentation
    }

    public class Subcommittee
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string chamber { get; set; }
        public string committee_id { get; set; }
    }

}
