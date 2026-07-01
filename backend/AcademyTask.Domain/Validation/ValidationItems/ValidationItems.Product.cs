using AcademyTask.Domain.Enums;

namespace AcademyTask.Domain.Validation.ValidationItems;

public static partial class ValidationItems
{
    public static class Product
    {
        public static string CodePrefix = nameof(Product);

        public static readonly ValidationItem MaxDescriptionLength = new()
        {
            Code = $"{CodePrefix}1",
            Message =
                $"Product description can be at most {Entities.Product.Product.MaxDescriptionLength} characters long.",
            ValidationSeverity = ValidationSeverity.Error,
            ValidationType = ValidationType.FormalValidation
        };
    }
}