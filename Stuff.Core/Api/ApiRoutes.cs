namespace Stuff.Core.Api
{
    /// <summary>
    /// Defines the routes to the different API routes we use in our application
    /// </summary>
    public class ApiRoutes
    {
        /// <summary>
        /// The routes to get a specific product by it's id
        /// </summary>
        public const string GetProduct = "/Product";

        /// <summary>
        /// The route to get all the available products
        /// </summary>
        public const string GetProductsList = "/Products";

        /// <summary>
        /// The route to create a new product
        /// </summary>
        public const string AddProduct = "/Product/Create";

        /// <summary>
        /// The route to update a product
        /// </summary>
        public const string UpdateProduct = "/Product/Update";
    }
}
