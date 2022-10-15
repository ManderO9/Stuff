namespace Stuff
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
    }
}