using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TestProject1;

public class ProductsGetIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    
    public ProductsGetIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_ReturnsSuccessCode()
    {
        //Act
        var response = await _client.GetAsync("/api/products");
        
        //Assert
        response.EnsureSuccessStatusCode();
    }
}