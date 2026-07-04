using AcademyTask.Domain.Interfaces.Common;
using AcademyTask.Domain.Interfaces.LikedProduct;
using AcademyTask.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AcademyTask.Infrastructure.Persistence.Repositories.LikedProduct;

public class LikedProductRepository : Repository<Domain.Entities.LikedProduct.LikedProduct, int>,  ILikedProductRepository
{
    public LikedProductRepository(DbContext context) : base(context) { }

    public async Task<List<Domain.Entities.Product.Product>> GetLikedProductsAsync(int userId)
    {
        var products = await DbSet.Where(likedProduct => likedProduct.UserId == userId)
            .Select(likedProduct => likedProduct.Product).ToListAsync();

        return products;
    }
}