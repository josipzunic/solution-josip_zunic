using AcademyTask.Domain.Enums;

namespace AcademyTask.Domain.Validation.ValidationItems;

public static partial class ValidationItems
{
    public static class LikedProduct
    {
        public static string CodePrefix = nameof(Product);

        public static readonly ValidationItem NonExistingEntity = new()
        {
            Code = $"{CodePrefix}1",
            Message =
                "Cannot create a like reference. Product or user does not exist",
            ValidationSeverity = ValidationSeverity.Error,
            ValidationType = ValidationType.FormalValidation
        };
    } 
}