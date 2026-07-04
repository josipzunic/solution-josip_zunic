using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.LikedProduct;
using AcademyTask.Domain.Entities.Product;

namespace AcademyTask.Application.Interfaces;

public interface ILikedProductService 
{
    Task<List<Product>> LoadLikedProductsAsync(int userId);
    Task<Result<LikedProduct>> CreateLikedProductAsync(int userId, int productId);
}