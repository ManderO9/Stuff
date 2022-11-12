namespace Stuff.Core
{
    /// <summary>
    /// Handles different API calls to the web server to get data, authentication, and add different things like products.
    /// </summary>
    public interface IAPIManager
    {
        /// <summary>
        /// Gets the list of products from the Web API
        /// </summary>
        /// <returns>An API response of <see cref="List{Product}<"/></returns>
        Task<ApiResponse<List<Product>>?> GetProducts();

        /// <summary>
        /// Returns the product with the passed in id
        /// </summary>
        /// <param name="id">The id of the product to get</param>
        /// <returns></returns>
        Task<ApiResponse<Product>?> GetProduct(string id);

        /// <summary>
        /// Updates the product in the server
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <returns></returns>
        Task<ApiResponse<Product>?> UpdateProduct(Product product);

        /// <summary>
        /// Creates a new product in the server and returns the created product
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <returns></returns>
        Task<ApiResponse<Product>?> CreateProduct(Product product);

    }
}
