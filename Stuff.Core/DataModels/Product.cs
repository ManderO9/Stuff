namespace Stuff.Core
{
    /// <summary>
    /// The product that we can have in our app
    /// </summary>
    public class Product
    {
        #region Public Properties

        /// <summary>
        /// The unique identifier of this object
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        public required string Description { get; set; }

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
        public string? ImageLink { get; set; }

        /// <summary>
        /// Alternative text to display to the user if we didn't find the display image
        /// </summary>
        public string? ImageAltText { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a displayable string for the price unit
        /// </summary>
        /// <returns></returns>
        public string GetDisplayPriceUnit()
        {
            // Switch the price unit
            switch (PriceUnit)
            {
                // If it's dollars
                case PriceUnit.Dollar:
                    return "$";

                // If it's dinnars
                case PriceUnit.Dinnar:
                    return "DZD";
            }

            // If no match, return an empty string
            return "";
        }

        #endregion

    }

}