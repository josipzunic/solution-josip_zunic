using AcademyTask.Application.Interfaces;
using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.Product;
using AcademyTask.Domain.Interfaces;
using AcademyTask.Domain.Interfaces.ExternalApi;
using AcademyTask.Domain.Validation;

namespace AcademyTask.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductSource _productSource;

    public ProductService(IProductRepository productRepository, IProductSource productSource)
    {
        _productRepository = productRepository;
        _productSource = productSource;
    }
    
    public async Task<List<Product>> FetchProductsExternalAsync()
    {
        var resultExternal = await _productSource.GetProductsAsync();
        
        if (resultExternal.ValidationResult.HasErrors || resultExternal.Value == null)
        {
            return new List<Product>(); 
        }
        
        var externalProducts = resultExternal.Value;
        var productsResults = new List<Product>();
        
        var incomingIds = externalProducts.Select(x => x.Id).ToList();
        var productsInDb = await _productRepository.GetAllAsync();
        var idsInDb = productsInDb.Select(x => x.ExternalId).ToList();

        foreach (var externalProduct in externalProducts)
        {
            var image = externalProduct.Images == null || externalProduct.Images.All(string.IsNullOrEmpty)
                ? null
                : externalProduct.Images.FirstOrDefault(image => !string.IsNullOrEmpty(image));
;           var result = Product.Create(
                externalProduct.Title,
                externalProduct.Description,
                image,
                externalProduct.Price,
                externalProduct.Category,
                externalProduct.Id);

            

            if (!result.ValidationResult.HasErrors && result.Value != null )
            {
                if (!productsResults.Any(p=> p.Id == externalProduct.Id) 
                    && !idsInDb.Contains(externalProduct.Id))
                {
                    await _productRepository.AddAsync(result.Value);
                    productsResults.Add(result.Value);   
                }
            }
        }

        await _productRepository.SaveAsync();
        return productsResults;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var result = await _productRepository.GetAllAsync();
        return result;
    }

    public async Task<List<Product>> GetProductsByNameAsync(string name)
    {
        var result =  await _productRepository.FindByNameAsync(name);
        return result;
    }

    public async Task<List<Product>> GetProductsByCategoryAndPriceAsync(List<string> category, decimal upperBound, decimal lowerBound)
    {
        var result = await _productRepository.FilterByCategoryAndPriceAsync(category, upperBound, lowerBound);
        return result;
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        var result = await _productRepository.GetByIdAsync(productId);
        return result;
    }
}