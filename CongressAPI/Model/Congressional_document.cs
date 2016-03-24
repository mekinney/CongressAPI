using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Congressional_document
    {
        public string bill_id { get; set; }
        public string bioguide_id { get; set; }
        public int? congress { get; set; }
        public string occurs_at { get; set; }
        public string version_code { get; set; }
        public string description { get; set; }
        public List<string> committee_names { get; set; }
        public string document_id { get; set; }
        public string type { get; set; }
        public List<Url> urls { get; set; }
        public string chamber { get; set; }
        public int? house_event_id { get; set; }
        public string text { get; set; }        // TODO: Is this huge?  Is a string the right type.
        public string text_preview { get; set; }
        public string committee_id { get; set; }
        public string hearing_title { get; set; }
        public Search search { get; set; }      // Search defined in Document definition.
        public Witness witness { get; set; }    // Uses Witness defined in Hearing.  Superset of this one adding a list of documents.
    }

    public class Url
    {
        public string permalink { get; set; }   // Permalink to document hosted by Sunlight Foundation
        public string url { get; set; }
    }

}
