using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;


namespace CongressAPI.Model
{

    public class Bill
    {

        // Properties included in Vote query
        public string bill_id { get; set; }
        public string bill_type { get; set; }
        public string chamber { get; set; }
        public List<string> committee_ids { get; set; }
        public int? congress { get; set; }
        public int? cosponsors_count { get; set; }
        public EnactedAs enacted_as { get; set; }
        public History history { get; set; }
        public DateTime? introduced_on { get; set; }
        public DateTime? last_action_at { get; set; }
        public LastVersion last_version { get; set; }
        public DateTime? last_version_on { get; set; }
        public DateTime? last_vote_at { get; set; }
        public int? number { get; set; }
        public string official_title { get; set; }
        public string popular_title { get; set; }
        public List<string> related_bill_ids { get; set; }
        public string short_title { get; set; }
        public Legislator sponsor { get; set; }
        public string sponsor_id { get; set; }
        public BillTextUrls urls { get; set; }
        public int? withdrawn_cosponsors_count { get; set; }

        // Additional properties available through Bill query
        public List<Action> actions { get; set; }
        public List<string> cosponsor_ids { get; set; }
        public List<Cosponsor> cosponsors { get; set; }
        public List<string> keywords { get; set; }
        public string summary { get; set; }
        public string summary_short { get; set; }
        public List<Title> titles { get; set; }
        public List<string> withdrawn_cosponsor_ids { get; set; }
        public List<Upcoming> upcoming { get; set; }
    }

    public class Cosponsor
    {
        public DateTime? sponsored_on { get; set; }
        public Legislator legislator { get; set; }
    }

    public class BillTextUrls
    {
        public string html { get; set; }
        public string pdf { get; set; }
        public string xml { get; set; }
    }

    public class LastVersion
    {
        public string version_code { get; set; }
        public DateTime? issued_on { get; set; }
        public string version_name { get; set; }
        public string bill_version_id { get; set; }
        public LandingPageUrls urls { get; set; }
        public int? pages { get; set; }
    }

    public class LandingPageUrls
    {
        public string congress { get; set; }
        public string govtrack { get; set; }
        public string opencongress { get; set; }
    }

    public class Action
    {
        public DateTime? acted_at { get; set; }
        public List<Reference> references { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public List<Committee> committees { get; set; }
        public string calendar { get; set; }
        public string number { get; set; }              //TODO: Verify - Not in API Documentation
        public string under { get; set; }               //TODO: Verify - Not in API Documentation - Contains "General Orders"
        public string how { get; set; }
        public string result { get; set; }
        public string vote_type { get; set; }
        public string chamber { get; set; }
        public string roll_id { get; set; }             //TODO: Verify - Not in API Documentation
        public List<string> bill_ids { get; set; }
        public object suspension { get; set; }          //TODO: Verify - Not in API Documentation
        public object in_subcommittee { get; set; }     //TODO: Verify - Not in API Documentation
    }

    public class History
    {
        // Properties returned in Vote query
        public bool? active { get; set; }
        public DateTime? active_at { get; set; }
        public bool? awaiting_signature { get; set; }
        public bool? enacted { get; set; }
        public bool? vetoed { get; set; }
        
        // Additional properties returned in Bill and Amendment queries. 
        public string house_passage_result { get; set; }
        public DateTime? house_passage_result_at { get; set; }
        public string senate_passage_result { get; set; }
        public DateTime? senate_passage_result_at { get; set; }
        public DateTime? vetoed_at { get; set; }
        public string senate_cloture_result { get; set; }
        public DateTime? senate_cloture_result_at { get; set; }
        public string senate_override_result { get; set; }
        public DateTime? senate_override_result_at { get; set; }
        public string house_override_result { get; set; }
        public DateTime? house_override_result_at { get; set; }
    }

    public class Title
    {
        public string assignedstate { get; set; }  // TODO: Fix - doesn't serialize. Renamed for .NET API because 'as' is a reserved word in C#.
        public string title { get; set; }
        public string type { get; set; }
    }

    public class Reference
    {
        public string reference { get; set; }
        public string type { get; set; }
    }

    public class EnactedAs
    {
        public int? congress { get; set; }
        public string law_type { get; set; }
        public int? number { get; set; }
    }

    public class Upcoming
    {
        public string source_type { get; set; }
        public string url { get; set; }
        public string chamber { get; set; }
        public int? congress { get; set; }
        public string range { get; set; }
        public DateTime? legislative_day { get; set; }
        public string context { get; set; }
    }

    public class BillDistinctComparer : IEqualityComparer<Bill>
    {
        public bool Equals(Bill x, Bill y)
        {
            return x.bill_id == y.bill_id;
        }

        public int GetHashCode(Bill obj)
        {
            return obj.bill_id.GetHashCode();
        }
    }
}
