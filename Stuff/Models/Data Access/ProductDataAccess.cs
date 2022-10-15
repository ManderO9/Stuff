using System.Net.Http.Json;

namespace Stuff
{
    /// <summary>
    /// Provides function to manipulate data for the products
    /// </summary>
    public class ProductDataAccess : IProductDataAccess
    {
        #region Private Members

        /// <summary>
        /// HTTP client to access different parts in our application from the client side
        /// </summary>
        private HttpClient mHttpClient { get; }

        /// <summary>
        /// The source of the products data
        /// </summary>
        private const string mProductsDataSource = "sample-data/products.json";

        #endregion

        #region Interface Implementation

        public async Task<List<Product>?> GetProducts()
        {
            // Return the data from the HTTP client call
            return await mHttpClient.GetFromJsonAsync<List<Product>>(mProductsDataSource);
        }
        
        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpClient">HTTP client to access different parts of our app</param>
        public ProductDataAccess(HttpClient httpClient)
        {
            // Set private members
            mHttpClient = httpClient;
        }

        #endregion

    }


}
