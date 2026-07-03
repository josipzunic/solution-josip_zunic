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
    private readonly IExternalProductApiClient _externalProductApiClient;

    public ProductService(IProductRepository productRepository, IExternalProductApiClient externalProductApiClient)
    {
        _productRepository = productRepository;
        _externalProductApiClient = externalProductApiClient;
    }
    
    public async Task<List<Product>> FetchProductsAsync()
    {
        var resultExternal = await _externalProductApiClient.GetProductsAsync();
        
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
    
    
}