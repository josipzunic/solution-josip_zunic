using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Validation;
using AcademyTask.Domain.Validation.ValidationItems;

namespace AcademyTask.Domain.Entities.Product;

public class Product
{
    public const int MaxDescriptionLength = 100;
    public const int MinNameLength = 2;
    public const int MaxNameLength = 100;
    
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? ImageUrl { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    private Product() {}

    public static Result<Product> Create(string name, string? description, string? imageUrl, decimal price)
    {
        var validationResult = new ValidationResult();
        
        if(!string.IsNullOrWhiteSpace(description) && description.Length > MaxDescriptionLength)
            validationResult.AddValidationItems(ValidationItems.Product.MaxDescriptionLength);
        if(price <= 0)
            validationResult.AddValidationItems(ValidationItems.Product.NegativeOrZeroPrice);
        if (string.IsNullOrWhiteSpace(name)|| name.Length < MinNameLength)
            validationResult.AddValidationItems(ValidationItems.Product.MinNameLength);
        else if (name.Length > MaxNameLength)
            validationResult.AddValidationItems(ValidationItems.Product.MaxNameLength);

        if (validationResult.HasErrors)
            return new Result<Product>(null, validationResult);

        var product = new Product()
        {
            Name = name,
            Description = description,
            ImageUrl = imageUrl,
            Price = price,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        return new Result<Product>(product, validationResult);
    }
}