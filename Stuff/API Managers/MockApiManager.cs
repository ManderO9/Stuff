using Stuff.Core;

namespace Stuff;

/// <summary>
/// A test implementation of the api manager
/// </summary>
public class MockApiManager : IAPIManager
{
	public async Task<ApiResponse<Product>?> CreateProduct(Product product)
	{
		await Task.Delay(0);
		return new ApiResponse<Product>()
		{
			Successful = true,
			Body = product
		};
	}
	public async Task<ApiResponse<Product>?> GetProduct(string id)
	{
		await Task.Delay(0);
		return new ApiResponse<Product>()
		{
			Successful = true,
			Body = new Product()
			{
				Description = "description",
				Id = id,
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHN8ZW58MHx8MHx8&w=1000&q=80"
			}
		};
	}
	public async Task<ApiResponse<List<Product>>?> GetProducts()
	{
		await Task.Delay(0);
		var products = new List<Product>() {
			 new Product()
			{
				Description = "description",
				Id = "some id1",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHN8ZW58MHx8MHx8&w=1000&q=80"
			},
			  new Product()
			{
				Description = "description",
				Id = "some id2",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHN8ZW58MHx8MHx8&w=1000&q=80"
			},
			   new Product()
			{
				Description = "description",
				Id = "some id3",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "https://www.junglescout.com/wp-content/uploads/2021/01/product-photo-water-bottle-hero.png"
			},
				new Product()
			{
				Description = "description",
				Id = "some id4",
				Name = "name",
				Price = 4,
				ImageAltText = "some image",
				PriceUnit = PriceUnit.Dollar,
				ImageLink = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHN8ZW58MHx8MHx8&w=1000&q=80"

			}
		};

		return new ApiResponse<List<Product>>() { Body = products, Successful = true };
	}
	public async Task<ApiResponse<Product>?> UpdateProduct(Product product)
	{
		await Task.Delay(0);
		return new ApiResponse<Product>()
		{
			Successful = true,
			Body = product
		};
	}
}
