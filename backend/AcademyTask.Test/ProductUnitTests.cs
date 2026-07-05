using AcademyTask.Domain.Entities.Product;
using Xunit;

namespace TestProject1;

public class ProductUnitTests
{
    [Fact]
    public void Create_NegativeOrZeroPriceProduct_ReturnsValidationError()
    {
        //Arange
        var price = -0.9m;
        
        //Act
        var product = Product.Create("šok žvaka", "", "", price,
            "groceries", 3);
        
        //Assert
        Assert.True(product.ValidationResult.HasErrors);
    }
}