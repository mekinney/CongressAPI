using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using CongressAPI.Model;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace CongressAPI
{

    public partial class CongressAPIRestClient
    {

        private readonly HttpClient _client;
        
        /// <summary>
        /// Base URL of API
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Your Sunlight API key.  Get one at: http://services.sunlightlabs.com/accounts/register/
        /// </summary>
        private string ApiKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CongresAPIRestClient"/> class.
        /// </summary>
        /// <param name="apiKey">The Sunlight Foundation API access key.</param>
        /// <param name="baseUrl">The base API URL. Defaults to: https://congress.api.sunlightfoundation.com/ </param>
        /// <exception cref="ArgumentNullException">API access key in null or empty.</exception>
        public CongressAPIRestClient(string apiKey, Uri baseURL)
        {

            // Validate parameters
            if (string.IsNullOrEmpty(apiKey))
                throw new CongressAPIHttpException("API Key is NULL and must be specified.");

            // Set any instance specific variables
            BaseUrl = baseURL.ToString();
            ApiKey = apiKey;

            _client = new HttpClient();
            _client.BaseAddress = baseURL;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CongresAPIRestClient"/> class.
        /// </summary>
        /// <param name="apiKey">The Sunlight Foundation API access key.</param>
        /// <exception cref="ArgumentNullException">API access key in null or empty.</exception>
        public CongressAPIRestClient(string apiKey)
            : this(apiKey, new Uri("https://congress.api.sunlightfoundation.com/"))
        {
        }

        /// <summary>
        /// Execute a manual REST request (async) utilizing the Congress API.  This routine adds all API
        /// specific credentials and security.  It knows nothing of the contents of the query.
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The formatted request string specifing the API query.</param>

        public virtual async Task<T> ExecuteAsync<T>(string request) where T : new()
        {

            string query = request + "&apikey="+ApiKey;
            Debug.WriteLine("ExecuteAsyn(): query='{0}'",query);

            HttpResponseMessage response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                throw new CongressAPIHttpException("Request: " + response.RequestMessage + "\n"+ response.ReasonPhrase + ": " + response.Content.ToString());
            }
 
            var l = await response.Content.ReadAsAsync<T>();

            return (l);

       }


        /// <summary>
        /// Get a list of resources using all field selection, sorting, and filtering.
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual async Task<CongressAPIResult<T>> GetResourcePageAsync<T>(string resource) where T : new()
        {

            var task = GetResourcePageAsync<T>(resource, null, null, null);
            var result = await task;

            return result;
        }

        /// <summary>
        /// Get a list of resources using all field selection, sorting, and filtering.
        ///
        /// Building a string in the format: 
        /// Specify the resource:            bills?
        /// Specify page number:             page=num
        /// Specify perPage:                 &per_page=num
        /// Specify filtering:               &fieldname =value&fieldname__oper=valueorlist
        /// Specify sorting:                 &order=fieldname__asc,fieldName__desc
        /// Specify fields to return:        &fieldname1,fieldname2
        /// Specify result sort order:       &order=fieldname__asc,fieldname2_desc
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.  This type must match the resource type being queried.</typeparam>
        /// <param name="resource">A string representing the resource to retrieve.</param>
        /// <param name="pageNum">An int specifying the page number to retrieve.  Defaults to 0, the first page.</param>
        /// <param name="perPage">An int specifying the number of records per page to retrieve.  Defaults to the maximum number of entries allowed by the API.</param>
        /// <param name="fieldList">A List of strings specifying the fields to be returned. Defaults to null, indicating return the default list (not recommended by the API).</param>
        /// <param name="sortList">A List of SortSpec items specifying the sort order to be returned. Defaults to null, indicating return the default list (not recommended by the API).</param>
        /// <param name="filterList">A List of FilterSpec items specifying the operators and constrainsts to filter the results by.  Defaults to null, indicating no filters.</param>
        /// 

        public virtual async Task<CongressAPIResult<T>> GetResourcePageAsync<T>(string resource, List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int? pageNum = null, int? perPage = null) where T : new()
        {

            // TODO: Add resource string validation.

            string query = BuildResourceQuery(resource, fieldList, sortList, filterList, pageNum, perPage);            

            var task = ExecuteAsync<CongressAPIResult<T>>(query);
            var result = await task; 

            // Save the finalQuery for diagnostic purposes.
            result.finalQuery = query;

            return result;
        }

        
        /// <summary>
        /// Execute a resource query and return the JSON response as a string.
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">A string representing a valid Congress API request.</param>
        public virtual async Task<string> GetResourceStringAsync(string request) 
        {

            string query = request + "&apikey=" + ApiKey;

            Debug.WriteLine("GetResourceStringAsync(): query='{0}",query);

            HttpResponseMessage response = await _client.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                throw new CongressAPIHttpException("Request: " + response.RequestMessage + "\n" + response.ReasonPhrase + ": " + response.Content.ToString());
            }

            string s;
            s = await response.Content.ReadAsStringAsync();

            return (s);

        }

        /// <summary>
        /// Build the proper Congress API query string based on the included parameters.
        /// See GetResourcePageAsync for the a description of the parameters.
        /// </summary>

        public string BuildResourceQuery(string resource, List<string> fieldList = null, List<SortSpec> sortList = null, List<FilterSpec> filterList = null, int? pageNum = null, int? perPage = null)

        {

            // TODO: Add resource string validation.
            // TODO: Use String builder class

            string query = @"/" + resource;

            // If the query contains a ? then we assume it's a partially formed query and we'll append additional properly
            // formatted parameters to it.
            char delimiter = query.Contains("?") ? '&' : '?';

            // Append page selection.
            if (pageNum != null)
            {
                query = query + delimiter + "page=" + pageNum;
                delimiter = '&';
            }

            // Append per_page value if it's less than the default (which is also the max)
            if (perPage != null)
            {
                query = query + delimiter + "per_page=" + perPage;
                delimiter = '&';
            }

            // TODO: Could create a class for parameters and then subclass specific types.  Put all of the looping
            // logic in one location.

            if (fieldList?.Count() > 0)
            {
                int numFields = fieldList.Count();
                int c = 1;

                query += delimiter;
                delimiter = '&';

                query += "fields=";

                foreach (string fieldName in fieldList)
                {
                    query += fieldName;
                    if (c++ < numFields) query += ',';
                }
            }

            if (sortList?.Count() > 0)
            {
                int numFields = sortList.Count();
                int c = 1;

                query += delimiter;
                delimiter = '&';

                query += "order=";

                foreach (SortSpec field in sortList)
                {
                    query += field.Parameterize();
                    if (c++ < numFields) query += ',';
                }
            }

            if (filterList?.Count() > 0)
            {
                int numFields = filterList.Count();
                int c = 1;

                query += delimiter;
                delimiter = '&';

                foreach (FilterSpec field in filterList)
                {
                    query += field.Parameterize();
                    if (c++ < numFields) query += delimiter;
                }
            }

            return query;
        }


    }


    public enum SortDirection
    {
        none,
        asc, 
        desc
    }

    public enum FilterOperator
    {
        gt,
        gte,
        lt,
        lte,
        not,
        all,
        oneof,
        nin,
        exists
    }

    public class SortSpec
    {
        public string FieldName { get; set; }
        public SortDirection? Order { get; set; }

        public SortSpec(string fieldName, SortDirection order)
        {
            FieldName = fieldName;
            Order = order;
        }

        public SortSpec(string fieldName)
        {
            FieldName = fieldName;
            Order = null;
        }

        public string Parameterize()
        {
            string s = FieldName;

            if (Order != null) {
                switch (Order)
                {
                    case SortDirection.asc: s += "__asc"; break;
                    case SortDirection.desc: s += "__desc"; break;
                }
            }
            return s;
        }
    }

    public class FilterSpec
    {
        string FieldName { get; set; }
        List<string> Operand { get; set; }
        FilterOperator? Operator { get; set; }

        public FilterSpec(string fieldName, List<string>operand)
        {
            FieldName = fieldName;
            Operand = operand;
            Operator = null;
        }

        public FilterSpec(string fieldName, List<string>operand, FilterOperator filterOperator)
        {
            FieldName = fieldName;
            Operator = filterOperator;
            Operand = operand;
        }

        public string Parameterize()
        {

            string s = FieldName;

            if (Operator != null)
            {
                s += "__";  // Pre-pend double underscore to operator.

                switch (Operator)
                {
                    case FilterOperator.gt: s += "gt"; break;
                    case FilterOperator.gte: s += "gte"; break;
                    case FilterOperator.lt: s += "lt"; break;
                    case FilterOperator.lte: s += "lte"; break;
                    case FilterOperator.not: s += "not"; break;
                    case FilterOperator.all: s += "all"; break;
                    case FilterOperator.oneof: s += "in"; break;
                    case FilterOperator.nin: s += "nin"; break;
                    case FilterOperator.exists: s += "exists"; break;
                }
            }

            s += '=';

            int numOperands = Operand.Count();
            int i = 1;
            foreach (string oper in Operand)
            {
                s += oper;
                if (i++ < numOperands) s += "|";  // Append an "|" if this isn't the last operand.
            }

            return s;
         
        }
    }
}
