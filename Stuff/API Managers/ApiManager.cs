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

		public async Task<ApiResponse<List<Product>>?> GetProductsAsync()
		{
			try
			{
				// Try get the list of products from the server
				var response = await mHttpClient.PostAsJsonAsync(mApiUrl + ApiRoutes.GetProductsList,
					// TODO: Add token authentication
					new ApiRequest() { Token = "" });

				// Read the result from the response
				var output = await response.Content.ReadFromJsonAsync<ApiResponse<List<Product>>?>();

				// Return the result
				return output;
			}
			catch(Exception ex)
			{
				// TODO: Log the error
				_ = ex;

				// Return an error
				return new ApiResponse<List<Product>>()
				{
					Successful = false,
					Errors = new List<string>() { "Unknown Error" }
				};
			}
		}

		public async Task<ApiResponse<Product>?> GetProductAsync(string id)
		{
			try
			{
				// Try get the product from the server
				var response = await mHttpClient.PostAsJsonAsync(mApiUrl + ApiRoutes.GetProductsList,
					// TODO: Add token authentication
					new ApiRequest<string>() { Token = "", Body = id });

				// Read the result from the response
				var output = await response.Content.ReadFromJsonAsync<ApiResponse<Product>?>();

				// Return the result
				return output;
			}
			catch(Exception ex)
			{
				// TODO: Log the error
				_ = ex;

				// Return an error
				return new ApiResponse<Product>()
				{
					Successful = false,
					Errors = new List<string>() { "Unknown Error" }
				};
			}
		}

		public async Task<ApiResponse<Product>?> UpdateProductAsync(Product product)
		{


			try
			{
				// Send an update request
				var response = await mHttpClient.PostAsJsonAsync(mApiUrl + ApiRoutes.UpdateProduct,
					// TODO: Add token authentication
					new ApiRequest<Product>() { Token = "", Body = product });

				// Read the result from the response
				var output = await response.Content.ReadFromJsonAsync<ApiResponse<Product>?>();

				// Return the result
				return output;
			}
			catch(Exception ex)
			{
				// TODO: Log the error
				_ = ex;

				// Return an error
				return new ApiResponse<Product>()
				{
					Successful = false,
					Errors = new List<string>() { "Unknown Error" }
				};
			}
		}

		public Task<ApiResponse<Product>?> CreateProductAsync(Product product)
		{
			throw new NotImplementedException();
		}


		#endregion
	}


}
