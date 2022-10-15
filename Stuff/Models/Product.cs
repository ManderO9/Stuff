namespace Stuff
{
    /// <summary>
    /// The product that we can have in our app
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// The unit of price we use for this product
        /// </summary>
        public PriceUnit PriceUnit { get; set; }

        /// <summary>
        /// The lint to the image for the current product
        /// </summary>
        public string ImageLink { get; set; }

        /// <summary>
        /// Alternative text to display to the user if we didn't find the display image
        /// </summary>
        public string ImageAltText { get; set; }
    }

}