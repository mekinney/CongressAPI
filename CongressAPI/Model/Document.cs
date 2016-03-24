using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    public class Document
    {
        public string document_type_name { get; set; }
        public DateTime? published_on { get; set; }
        public List<string> categories { get; set; }
        public string document_id { get; set; }
        public string posted_at { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string source_url { get; set; }
        public string document_type { get; set; }
        public Search search { get; set; }
        public GaoReport gao_report { get; set; }
        public IgReport ig_report { get; set; }

    }

    public class Search
    {
        public int score { get; set; }
        public string type { get; set; }
    }

    public class IgReport
    {
        public string topic { get; set; }
        public Pdf pdf { get; set; }
        public string published_on { get; set; }
        public string agency { get; set; }
        public string agency_name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string file_type { get; set; }
        public string title { get; set; }
        public string report_id { get; set; }
        public int year { get; set; }

        // The following aren't included in the official Congress v3 definition
        // so they are considered experimental per the documentation.
        // They were discovered during development and testing.  No concerted effort was
        // made to find all experimental properties.

        public string inspector_url { get; set; }
        public string inspector { get; set; }
        public string summary_url { get; set; }
        public bool summary_only { get; set; }
    }

    public class GaoReport
    {
        public string report_number { get; set; }
        public object supplement_url { get; set; }
        public string gao_id { get; set; }
        public string description { get; set; }
        public object links { get; set; }
        public object youtube_id { get; set; }
    }

    public class Pdf
    {
        public string modification_date { get; set; }
        public string creation_date { get; set; }
        public string author { get; set; }
        public int page_count { get; set; }

    }

}
