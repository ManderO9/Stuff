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

            // Get the list of products
            mProducts = await productDataAccess.GetProducts();
        }
    }
}