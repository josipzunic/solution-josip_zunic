using AcademyTask.Domain.Interfaces;
using AcademyTask.Domain.Interfaces.Common;
using AcademyTask.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AcademyTask.Infrastructure.Persistence.Repositories.Product;

public class ProductRepository : Repository<Domain.Entities.Product.Product, int>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context) {}

    public async Task<List<Domain.Entities.Product.Product>> FindByNameAsync(string name)
    {
        return await  DbSet.Where(product => product.Name.ToLower().Contains(name)).ToListAsync();
    }

    public async Task<List<Domain.Entities.Product.Product>> FilterByCategoryAndPriceAsync(List<string> categories, 
        decimal upperBound, decimal lowerBound)
    {
        List<Domain.Entities.Product.Product> filteredProducts;

        if (categories.Count > 0)
            filteredProducts = await DbSet.Where(product => categories.Contains(product.Category)).ToListAsync();
        else 
            filteredProducts = await DbSet.ToListAsync();

        if (upperBound > 0)
            filteredProducts = filteredProducts.Where(product => product.Price <= upperBound).ToList();

        if (lowerBound > 0)
            filteredProducts = filteredProducts.Where(product => product.Price >= lowerBound).ToList();

        return filteredProducts;

    }
}