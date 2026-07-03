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
        
        public static readonly ValidationItem NegativeOrZeroPrice = new()
        {
            Code = $"{CodePrefix}2",
            Message =
                $"Product price cannot be negative or zero.",
            ValidationSeverity = ValidationSeverity.Error,
            ValidationType = ValidationType.FormalValidation
        };
        
        public static readonly ValidationItem MinNameLength = new()
        {
            Code = $"{CodePrefix}3",
            Message =
                $"Product name must be at least {Entities.Product.Product.MinNameLength} characters long.",
            ValidationSeverity = ValidationSeverity.Error,
            ValidationType = ValidationType.FormalValidation
        };
        
        public static readonly ValidationItem MaxNameLength = new()
        {
            Code = $"{CodePrefix}4",
            Message =
                $"Product cannot be longer than {Entities.Product.Product.MaxNameLength} characters long.",
            ValidationSeverity = ValidationSeverity.Error,
            ValidationType = ValidationType.FormalValidation
        };

        public static readonly ValidationItem NullExternalProducts = new()
        {
            Code = $"{CodePrefix}5",
            Message =
                $"External Api did not retrieve any products",
            ValidationSeverity = ValidationSeverity.Error,
            ValidationType = ValidationType.SystemError
        };
    }
}