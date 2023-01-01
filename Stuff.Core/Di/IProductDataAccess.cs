namespace Stuff.Core
{
    /// <summary>
    /// Provides function to manipulate data for the products
    /// </summary>
    public interface IProductDataAccess
    {
        /// <summary>
        /// Returns the list of products we have in our application
        /// </summary>
        /// <returns></returns>
        Task<List<Product>?> GetProducts();

        /// <summary>
        /// Returns the product with the specified id or null if it doesn't exist
        /// </summary>
        /// <param name="id">The id of the product to get</param>
        /// <returns></returns>
        Task<Product?> GetProduct(string id);

        /// <summary>
        /// Updates a product in the database and returns a list of errors if any or and empty list if none
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <returns></returns>
        Task<List<string>> UpdateProduct(Product product);

        /// <summary>
        /// Creates a product in the database, returns a list of errors if any or an empty list if none
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <returns></returns>
        Task<List<string>> CreateProduct(Product product);   
    }
}