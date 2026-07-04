using AcademyTask.Domain.Entities.Product;
using AcademyTask.Domain.Interfaces.Common;

namespace AcademyTask.Domain.Interfaces.LikedProduct;

public interface ILikedProductRepository : IRepository<Domain.Entities.LikedProduct.LikedProduct, int>
{
    Task<List<Product>> GetLikedProductsAsync(int userId);
}