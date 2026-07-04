using AcademyTask.Domain.Entities.Product;

namespace AcademyTask.Application.Interfaces;

public interface IProductService
{
    Task<List<Product>> FetchProductsExternalAsync();
    Task<List<Product>> GetAllProductsAsync();
    Task<List<Product>> GetProductsByNameAsync(string name);
    Task<List<Product>> GetProductsByCategoryAndPriceAsync(List<string> category, decimal upperBound, decimal lowerBound);
    Task<Product?> GetProductByIdAsync(int productId);
}