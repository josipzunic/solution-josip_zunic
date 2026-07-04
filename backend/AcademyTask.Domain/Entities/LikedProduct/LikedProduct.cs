using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Validation;

namespace AcademyTask.Domain.Entities.LikedProduct;

public class LikedProduct
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int ProductId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public User.User User { get; private set; } = null!;
    public Product.Product Product { get; private set; } = null!;
    
    private LikedProduct() {}

    public static Result<LikedProduct> CreateLikedProduct(int userId, int likedProductId)
    {
        var likedProduct = new LikedProduct
        {
            UserId = userId,
            ProductId = likedProductId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return new Result<LikedProduct>(likedProduct, new ValidationResult());
    }
}