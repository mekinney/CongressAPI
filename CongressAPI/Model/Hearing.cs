using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Hearing
    {
        public string committee_id { get; set; }
        public DateTime? occurs_at { get; set; }
        public int? congress { get; set; }
        public string chamber { get; set; }
        public bool dc { get; set; }
        public string room { get; set; }
        public string description { get; set; }
        public List<string> bill_ids { get; set; }
        public string url { get; set; }
        public string hearing_type { get; set; }
        public HearingCommittee committee { get; set; }
        public List<Witness> witnesses { get; set; }
        public List<MeetingDocument> meeting_documents { get; set; }

        public int house_event_id { get; set; }
        public string hearing_id { get; set; }
    }

    public class HearingCommittee
    {
        public string address { get; set; }
        public string chamber { get; set; }
        public string committee_id { get; set; }
        public string name { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public bool subcommittee { get; set; }
    }

    // Used in Document_search also.
    public class Witness
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string organization { get; set; }
        public string position { get; set; }
        public string witness_type { get; set; }
        public List<WitnessDocument> documents { get; set; }
    }

    public class WitnessDocument
    {
        public string description { get; set; }
        public DateTime published_at { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string permalink { get; set; }
    }

    public class MeetingDocument
    {
        public string description { get; set; }
        public DateTime published_at { get; set; }
        public string type { get; set; }
        public string version_code { get; set; }
        public string bioguide_id { get; set; }
        public string bill_id { get; set; }
        public string url { get; set; }
        public string permalink { get; set; }
    }

}
