CongressAPI.NET
===============

This project wraps the Sunlight Foundation's Congress API with a strongly typed asyncronous .NET portable class library. 

Sample Usage
************

::

	using CongressAPI;
	using CongressAPI.Model;
	
	var CongressAPI = new CongressAPIRestClient("Enter your sunlight API Key Here");

	List<string> fieldList = new List<string> { "bill_id", "official_title","short_title","keywords","sponsor","sponsor_id","bill","titles" };
	List<SortSpec> sortList = new List<SortSpec> { new SortSpec("sponsor_id", SortDirection.asc) } ;
	List<FilterSpec> filterList = new List<FilterSpec> { new FilterSpec("sponsor_id", new List<string> { "L000585", "C001047" }, FilterOperator.oneof)} ;
	
	var b = await CongressAPI.GetBillsPageAsync(fieldList, sortList, filterList);
	Console.WriteLine("After GetBills Count: {0}", b.Results.Count() );

API Key
************

When enhancing / debugging this library, the unit tests expect the Sunlight API token to be located
in CongressAPI.Tests/Support/api_token.private.

To register for an API key, if you don't have one, please fill out the form
`here <http://services.sunlightlabs.com/accounts/register/>`_.


Contribute
**********

Contributions to this library are always welcome.  Please participate via github.
