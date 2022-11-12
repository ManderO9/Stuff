using Microsoft.AspNetCore.Mvc;
using Stuff.Core;
using Stuff.Core.Api;

namespace Stuff.Server.Controllers
{
    public class ApiController : Controller
    {
        #region Private Members

        /// <summary>
        /// Data access class for products
        /// </summary>
        private IProductDataAccess mProductData;

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="productData">The data access class for products</param>
        public ApiController(IProductDataAccess productData)
        {
            mProductData = productData;
        }

        #endregion

        #region API Calls

        /// <summary>
        /// Returns a response containing the requested product or an error if it doesn't exist
        /// </summary>
        /// <param name="request">The request containing the id of the product to get</param>
        /// <returns></returns>
        [Route(ApiRoutes.GetProduct)]
        public async Task<ActionResult<ApiResponse<Product>>> GetProduct([FromBody] ApiRequest<string> request)
        {
            // TODO: Check the token

            // If the request body was empty
            if (request == null || string.IsNullOrEmpty(request.Body))
                // Return an error
                return new ApiResponse<Product> { Errors = new List<string>() { "The id of the product to get was empty" } };

            // Get the product from the data store
            var result = await mProductData.GetProduct(request.Body);

            // If it exists
            if (result != null)
                // Return success response containing the product
                return new ApiResponse<Product>() { Successful = true, Body = result };

            // Otherwise, return an error
            return new ApiResponse<Product>() { Errors = new List<string>() { "Couldn't find the requested product" } };
        }

        /// <summary>
        /// Creates a product in the persistent store, returns the product if successful or a list of errors if not
        /// </summary>
        /// <param name="request">The request containing the product to create</param>
        /// <returns></returns>
        [Route(ApiRoutes.AddProduct)]
        public async Task<ActionResult<ApiResponse<Product>>> CreateProduct([FromBody] ApiRequest<Product> request)
        {
            // TODO: Check the token

            // If the request body was empty
            if (request == null || request.Body is null)
                // Return an error
                return new ApiResponse<Product> { Errors = new List<string>() { "The request body was null" } };

            // Create a new id for the product
            request.Body.Id = Guid.NewGuid().ToString("N");

            // Try create the product in the store
            var result = await mProductData.CreateProduct(request.Body);

            // If there were no errors            
            if (result == null)
                // Return success response
                return new ApiResponse<Product>() { Successful = true, Body = request.Body };

            // Otherwise, return an error
            return new ApiResponse<Product>() { Errors = result };
        }

        /// <summary>
        /// Returns the list of available products in our app or null if none exist
        /// </summary>
        /// <param name="request">The API request</param>
        /// <returns></returns>
        [Route(ApiRoutes.GetProductsList)]
        public async Task<ActionResult<ApiResponse<List<Product>?>>> GetProducts([FromBody] ApiRequest<byte> request)
        {
            // TODO: Check the token

            // If the request was null
            if (request == null)
                // Return an error
                return new ApiResponse<List<Product>?> { Errors = new List<string>() { "The request body was null" } };

            // Create a new response
            var response = new ApiResponse<List<Product>?>() { Successful = true };

            // Get the data from the database
            response.Body = await mProductData.GetProducts();

            // Return the response
            return response;
        }

        /// <summary>
        /// Updates a product in the persistent store
        /// </summary>
        /// <param name="request">The request containing the product to update</param>
        /// <returns></returns>
        [Route(ApiRoutes.UpdateProduct)]
        public async Task<ActionResult<ApiResponse<Product>>> UpdateProduct([FromBody] ApiRequest<Product> request)
        {
            // TODO: Check the token

            // If the request body was empty
            if (request == null || request.Body is null)
                // Return an error
                return new ApiResponse<Product> { Errors = new List<string>() { "The request body was null" } };

            // Try update the product in the database
            var result = await mProductData.UpdateProduct(request.Body);

            // If there was no errors
            if (result == null)
                // Return a success result
                return new ApiResponse<Product>() { Successful = true, Body = request.Body };

            // Otherwise, return an error
            return new ApiResponse<Product>() { Errors = result, Successful = false };
        }

        #endregion
    }
}
