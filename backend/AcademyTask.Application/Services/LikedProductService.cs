using AcademyTask.Application.Interfaces;
using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.LikedProduct;
using AcademyTask.Domain.Entities.Product;
using AcademyTask.Domain.Interfaces;
using AcademyTask.Domain.Interfaces.LikedProduct;
using AcademyTask.Domain.Validation;
using AcademyTask.Domain.Validation.ValidationItems;

namespace AcademyTask.Application.Services;

public class LikedProductService : ILikedProductService
{
    private readonly ILikedProductRepository _likedProductRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public LikedProductService(ILikedProductRepository likedProductRepository,
        IUserRepository userRepository, 
        IProductRepository productRepository)
    {
        _likedProductRepository = likedProductRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<List<Product>> LoadLikedProductsAsync(int userId)
    {
        return await _likedProductRepository.GetLikedProductsAsync(userId);
    }

    public async Task<Result<LikedProduct>> CreateLikedProductAsync(int userId, int productId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var product = await _productRepository.GetByIdAsync(productId);
        var validationResult = new ValidationResult();
        
        if(user == null || product == null)
            validationResult.AddValidationItems(ValidationItems.LikedProduct.NonExistingEntity);

        if (validationResult.HasErrors)
            return new Result<LikedProduct>(null, validationResult);

        var likedProduct = LikedProduct.CreateLikedProduct(userId, productId);

        likedProduct.Value!.SetProduct(product!);
        
        await _likedProductRepository.AddAsync(likedProduct.Value!);
        await _likedProductRepository.SaveAsync();

        return likedProduct;
    }
}