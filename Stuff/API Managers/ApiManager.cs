using Stuff.Core;
using Stuff.Core.Api;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stuff
{
    /// <summary>
    /// Provides function to manipulate data for the products
    /// </summary>
    public class ApiManager : IAPIManager
    {
        #region Private Members

        /// <summary>
        /// HTTP client to access different parts in our application from the client side
        /// </summary>
        private HttpClient mHttpClient { get; }

        /// <summary>
        /// The API URL to send requests to
        /// </summary>
        private string mApiUrl;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration">The app config file</param>
        /// <param name="httpClient">HTTP client to access different parts of our app</param>
        public ApiManager(HttpClient httpClient, IConfiguration configuration)
        {
            // Set private members
            mHttpClient = httpClient;

            // Set the url to the server
            mApiUrl = configuration.GetValue<string>("ServerAddress") ?? "";
        }

        #endregion

        #region Public Methods

        public async Task<ApiResponse<List<Product>>?> GetProducts()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, mApiUrl + ApiRoutes.GetProductsList);


            var content = JsonSerializer.Serialize<ApiRequest<byte>>(new ApiRequest<byte>());

            request.Content = new StringContent(content);

            var response = await mHttpClient.SendAsync(request);
            var output = await response.Content.ReadFromJsonAsync<ApiResponse<List<Product>>?>();



            return output;
        }
        public async Task<ApiResponse<Product>?> GetProduct(string id)
            => await mHttpClient.GetFromJsonAsync<ApiResponse<Product>?>(mApiUrl + ApiRoutes.GetProduct + $"/{id}");


        public async Task<ApiResponse<Product>?> UpdateProduct(Product product)
        {
            // Create the request to send
            var request = new HttpRequestMessage(HttpMethod.Post, mApiUrl + ApiRoutes.UpdateProduct);

            // Create the body of the request
            var jsonContent = JsonSerializer.Serialize(new ApiRequest<Product>() { Body = product });

            // Add it to the request
            request.Content = new StringContent(jsonContent);

            // Send the request and await the result
            var result = await mHttpClient.SendAsync(request);

            // Get the content of the response
            var content = await result.Content.ReadAsStringAsync();

            // Return the response
            return JsonSerializer.Deserialize<ApiResponse<Product>?>(content);
        }

        public Task<ApiResponse<Product>?> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        #endregion
    }


}
