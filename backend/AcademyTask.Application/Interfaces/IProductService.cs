using AcademyTask.Domain.Entities.Product;

namespace AcademyTask.Application.Interfaces;

public interface IProductService
{
    Task<List<Product>> FetchProductsAsync();
}