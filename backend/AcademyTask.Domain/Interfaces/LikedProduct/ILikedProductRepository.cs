using AcademyTask.Domain.Entities.Product;

namespace AcademyTask.Domain.Interfaces.LikedProduct;

public interface ILikedProductRepository
{
    Task<List<Product>> GetLikedProductsAsync(int userId, int likedProductId);
}