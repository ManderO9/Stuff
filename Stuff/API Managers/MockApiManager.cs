using Stuff.Core;

namespace Stuff;

/// <summary>
/// A test implementation of the api manager
/// </summary>
public class MockApiManager : IAPIManager
{
	public async Task<ApiResponse<Product>?> CreateProductAsync(Product product)
	{
		await Task.Delay(0);
		return new ApiResponse<Product>()
		{
			Successful = true,
			Body = product
		};
	}
	public async Task<ApiResponse<Product>?> GetProductAsync(string id)
	{
		await Task.Delay(0);
		return new ApiResponse<Product>()
		{
			Successful = true,
			Body = new Product()
			{
				Description = "In their product descriptions, Innocent emphasizes the few elements that make their smoothies “great” and “healthy.”\r\n\r\nYou see, they even highlighted in green that their smoothie is, “a source of vitamins C, B2, B3 and B6 which can help reduce tiredness and fatigue…”\r\n\r\nNow that’s the kind of solid argument we’re talking about",
				Id = id,
				Name = "Viral social proof",
				Price = 434,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "/Images/mount-kilimanjaro.jpg"
            }
		};
	}
	public async Task<ApiResponse<List<Product>>?> GetProductsAsync()
	{
		await Task.Delay(0);
		var products = new List<Product>() {
			 new Product()
			{
				Description = "description",
				Id = "some id1",
				Name = "Addictive product suggestions",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "/Images/red-tree.jpg"
            },
			  new Product()
			{
				Description = "description",
				Id = "some id2",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "/Images/sky.jpg"
            },
			   new Product()
			{
				Description = "description",
				Id = "some id3",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "/Images/lave.jpg"
            },
				new Product()
			{
				Description = "description",
				Id = "some id4",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "/Images/lave.jpg"

        }
    };

    public async Task<ApiResponse<Product>?> CreateProductAsync(Product product)
    {
        await Task.Delay(0);
        mProducts.Add(product);

        return new ApiResponse<Product>()
        {
            Successful = true,
            Body = product
        };
    }
    public async Task<ApiResponse<Product>?> GetProductAsync(string id)
    {
        await Task.Delay(0);
        return new ApiResponse<Product>()
        {
            Successful = true,
            Body = mProducts.First(x => x.Id == id)
        };
    }
    public async Task<ApiResponse<List<Product>>?> GetProductsAsync()
    {
        await Task.Delay(0);
        return new ApiResponse<List<Product>>() { Body = mProducts, Successful = true };
    }
    public async Task<ApiResponse<Product>?> UpdateProductAsync(Product product)
    {
        await Task.Delay(0);
        var oldProduct = mProducts.Where(p => p.Id == product.Id).First();
        mProducts.Remove(oldProduct);
        mProducts.Add(product);
        return new ApiResponse<Product>()
        {
            Successful = true,
            Body = product
        };
    }
}
