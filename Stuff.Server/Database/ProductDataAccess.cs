using Microsoft.EntityFrameworkCore;
using Stuff.Core;

namespace Stuff.Server
{
    /// <summary>
    /// Provides functions to manipulate the products in the persistent store
    /// </summary>
    public class ProductDataAccess : IProductDataAccess
    {
        #region Private Members

        /// <summary>
        /// The db context of the app
        /// </summary>
        private ApplicationDbContext mDbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The db context of the app</param>
        public ProductDataAccess(ApplicationDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<List<string>> CreateProduct(Product product)
        {
            // If the product is null
            if (product == null)
                // Return an error
                return new List<string>() { "Product is null" };

            // Create the list of errors
            var errors = new List<string>();

            // If the name of the product is empty
            if (string.IsNullOrEmpty(product.Name))
                // Add an error to the list of errors
                errors.Add("Product name can't be empty" );

            // If the id of the product is empty
            if (string.IsNullOrEmpty(product.Id))
                // Add an error to the list of errors
                errors.Add("Product id can't be empty");

            // If there was an error
            if (errors.Count > 0)
                // Return the errors
                return errors;
            
            // Otherwise, add the product to the database
           mDbContext.Products.Add(product);

            // Save the changes
            await mDbContext.SaveChangesAsync();

            // Return the empty errors
            return errors;
        }

        public Task<Product?> GetProduct(string id)
        {
            // Return the product with the specified id if any
            return Task.FromResult(mDbContext.Products.FirstOrDefault(x => x.Id == id));
        }

        public async Task<List<Product>?> GetProducts()
        {
            // Return all the products
            return await mDbContext.Products.ToListAsync();
        }

        public async Task<List<string>> UpdateProduct(Product product)
        {
            // If the product is null
            if (product == null)
                // Return an error
                return new List<string>() { "Product is null" };

            // Create the list of errors
            var errors = new List<string>();

            // If the name of the product is empty
            if (string.IsNullOrEmpty(product.Name))
                // Add an error to the list of errors
                errors.Add("Product name can't be empty");

            // If the id of the product is empty
            if (string.IsNullOrEmpty(product.Id))
                // Add an error to the list of errors
                errors.Add("Product id can't be empty");

            // If there was an error
            if (errors.Count > 0)
                // Return the errors
                return errors;

            // Otherwise, update the product in the database
            mDbContext.Products.Update(product);

            // Save the changes
            await mDbContext.SaveChangesAsync();

            // Return the empty errors
            return errors;
        }

        #endregion
    }
}
