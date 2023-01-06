using Stuff.Core;

namespace Stuff;

/// <summary>
/// A test implementation of the api manager
/// </summary>
public class MockApiManager : IAPIManager
{

    private List<Product> mProducts = new List<Product>()
    {
        new Product()
        {
            Description = "A cyclic redundancy check (CRC) is an error-detecting code commonly used in digital networks and storage devices to detect accidental changes to digital data. Blocks of data entering these systems get a short check value attached, based on the remainder of a polynomial division of their contents. On retrieval, the calculation is repeated and, in the event the check values do not match, corrective action can be taken against data corruption. CRCs can be used for error correction (see bitfilters).",
            Id = "id1",
            Name = "Addictive product suggestions",
            Price = 4,
            ImageAltText = "some image",
            PriceUnit = PriceUnit.Dollar,
            ImageLink = ApplicationRoutes.RoutePrefix + "/Images/red-tree.jpg"
        },
        new Product()
        {
            Description = "CRCs are based on the theory of cyclic error-correcting codes. The use of systematic cyclic codes, which encode messages by adding a fixed-length check value, for the purpose of error detection in communication networks, was first proposed by W. Wesley Peterson in 1961.[2] Cyclic codes are not only simple to implement but have the benefit of being particularly well suited for the detection of burst errors: ",
            Id = "fddid2",
            Name = "introduction",
            Price = 4,
            ImageAltText = "some image",
            PriceUnit = PriceUnit.Dollar,
            ImageLink = ApplicationRoutes.RoutePrefix + "/Images/sky.jpg"
        },
        new Product()
        {
            Description = "A CRC-enabled device calculates a short, fixed-length binary sequence, known as the check value or CRC, for each block of data to be sent or stored and appends it to the data, forming a codeword. ",
            Id = "somesdfds",
            Name = "name",
            Price = 4,
            ImageAltText = "some image",
            PriceUnit = PriceUnit.Dollar,
            ImageLink = ApplicationRoutes.RoutePrefix + "/Images/lave.jpg"
        },
        new Product()
        {
            Description = "Specification of a CRC code requires definition of a so-called generator polynomial. This polynomial becomes the divisor in a polynomial long division, which takes the message as the dividend and in which the quotient is discarded and the remainder becomes the result. The important caveat is that the polynomial coefficients are calculated according to the arithmetic of a finite field, so the addition operation can always be performed bitwise-parallel (there is no carry between digits).\r\n\r\nIn practice, all commonly used CRCs employ the Galois field, or more simply a finite field, of two elements, GF(2). The two elements are usually called 0 and 1, comfortably matching computer architecture.\r\n\r\nA CRC is called an n-bit CRC when its check value is n bits long. For a given n, multiple CRCs are possible, each with a different polynomial. Such a polynomial has highest degree n, which means it has n + 1 terms. In other words, the polynomial has a length of n + 1; its encoding requires n + 1 bits. Note that most polynomial specifications either drop the MSB or LSB, since they are always 1. The CRC and associated polynomial typically have a name of the form CRC-n-XXX as in the table below. ",
            Id = "fzreid4",
            Name = "name",
            Price = 4,
            ImageAltText = "some image",
            PriceUnit = PriceUnit.Dollar,
            ImageLink = ApplicationRoutes.RoutePrefix + "/Images/lave.jpg"

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
