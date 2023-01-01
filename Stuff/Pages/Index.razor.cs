using Stuff.Core;

namespace Stuff
{
    /// <summary>
    /// The home page of the application
    /// </summary>
    public partial class Index
    {
        /// <summary>
        /// The list of products that we display in this page
        /// </summary>
        private List<Product>? mProducts;

        protected override async Task OnInitializedAsync()
        {
            // TODO: add lazy loading

            // Get the list of products from the server
            var response = await apiManager.GetProducts();

            // If there was a response and it was successful
            if(response is not null && response.Successful)

                // Set the list of products
                mProducts = response.Body;
        }
    }
}