using AcademyTask.Domain.Entities.Product;
using AcademyTask.Domain.Interfaces.Common;

namespace AcademyTask.Domain.Interfaces;

public interface IProductRepository : IRepository<Product, int>
{ 
    Task<List<Product>> FindByNameAsync(string name);
    Task<List<Product>> FilterByCategoryAndPriceAsync(List<string> categories, decimal upperBound, decimal lowerBound);
}