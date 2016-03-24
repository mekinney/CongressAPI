To do:
Create / Modify each test to work with this.
Figure out best practice for testing Async methods.
Write some real world examples.


legislatorResourceWillReturnALegislatorForAll

Trading off flexibility for strongly typed
Legislators options
Apikey=[your api key]
fields=field1,field2,field3
Filtering:
Fieldname=value&fieldname=value
Put strings in quotes
true and false are interpreted
Operators - https://sunlightlabs.github.io/congress/
	page=3
	per_page=50 (max)
	order=fieldname__asc|desc,fieldname__asc|desc,…
all_legislators=true (all currently serving members)
query=string (searches all legislator’s name fields)
per_page=all (disable pagination but forces in_office=true)

General API Format:
/<Resource Type>?<API>&[Filtering]&[FieldList w Sorting]
Filter = <FieldName>=Value
			| <FieldName>__<Operator>=Value
Filtering = Filter[&Filter]...

legislators/locate

Possible Issues:
1. Do multiple concurrent async Get????? requests actually work in parallel?  It appears to be only a single query string per APIRestClient.
2. Get single resource code paths don't appear to be tested / used.  Do we even want them?
3. How to handle fields in a class that aren't always present.  specifically classes, etc.
4. Fix URL descriptions - BILL Text URLS, Bill Website URLS
5. Amendment sponsor - can be a committee.  Bill sponsors must be a person.
6. Test descriptions - escaped quotes, /n and others.
7. None of the string parameters are validated the API will take invalid ones and simply ignore them.


API Feedback
property named "as".  "as" is a c# key word.  Bills->Titles->assignedstate
URLS - two properties with same name but very different meanings.  BillTextURLs and LandingPageURLS?
Witness - Defined slightly differently in Document_search and Hearing
Document defined in Hearing - changed to WitnessDocument - very different format that overall Document
Query parameter - consistentency
bills.actions.suspension and in_subcommittee - no documentation
legislators.alias or other_names?
legislators.terms.class - class is a reserved word in C#.




To do:
1. query for withrdrawn co-sponsor count > 1 to check for format of result.
Minimum Releasable To do:
1. Handle pagination of responses.
	<DONE>a. Expose API that supports this.
	b. Implement autmated multi-requests to return all results?
2. Handle all API elements.
	<DONE>Bills, districts, committees, amendments, nominations, floor_updates, hearings, upcoming bills,
	congressional_documents, documents
3. Minimal Error checking
4. Documentation
5. Clean out unused code
6. Document code
7. Minimal self tests (web connection, specific return results, ?)
8. legislators/locate
9. bills/search query parameter
10. committees - per_page=all
11. Nominations - query parameter
12. votes - query parameter
13. hearings - query parameter
14. documents/search - no query option in
15. Use date/time fields instead of strings.
16. Add versions to bills model
17. Add support for this: /votes?amendment_id=hamdt935-113 is a valid request.


Other Todo:
1. Create enumerated types for properties that have them.
2. Put all common Model items in a common file

Ideas:
1. Figure how to make an Excel Plugin - extract votes to Excel...
	a. Maybe lists of legislators - easier to use.




