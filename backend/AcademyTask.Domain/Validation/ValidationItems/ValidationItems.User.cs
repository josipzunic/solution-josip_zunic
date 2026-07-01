using AcademyTask.Domain.Enums;

namespace AcademyTask.Domain.Validation.ValidationItems;

public static partial class ValidationItems
{
    public static class User
    {
        public static string CodePrefix = nameof(User);

        public static readonly ValidationItem MinUsernameLength = new()
        {
            Code = $"{CodePrefix}1",
            Message = $"Username must be at least {Entities.User.User.MinUsernameLength} character long.",
            ValidationType = ValidationType.FormalValidation,
            ValidationSeverity = ValidationSeverity.Error
        };

        public static readonly ValidationItem MaxUsernameLength = new()
        {
            Code = $"{CodePrefix}2",
            Message = $"Username can contain at most {Entities.User.User.MaxUsernameLength} characters.",
            ValidationType = ValidationType.FormalValidation,
            ValidationSeverity = ValidationSeverity.Error
        };

        public static readonly ValidationItem MinPasswordLength = new()
        {
            Code = $"{CodePrefix}3",
            Message = $"Password must be at least {Entities.User.User.MinPasswordLength} character long.",
            ValidationType = ValidationType.FormalValidation,
            ValidationSeverity = ValidationSeverity.Error
        };
        
        public static readonly ValidationItem MaxPasswordLength = new()
        {
            Code = $"{CodePrefix}4",
            Message = $"Password can contain at most {Entities.User.User.MaxPasswordLength} characters.",
            ValidationType = ValidationType.FormalValidation,
            ValidationSeverity = ValidationSeverity.Error
        };

        public static readonly ValidationItem EmailRequired = new()
        {
            Code = $"{CodePrefix}5",
            Message = $"Email is required.",
            ValidationType = ValidationType.FormalValidation,
            ValidationSeverity = ValidationSeverity.Error
        };

        public static readonly ValidationItem EmailUnique = new()
        {
            Code = $"{CodePrefix}6",
            Message = $"Email already exists.",
            ValidationType = ValidationType.BusinessRule,
            ValidationSeverity = ValidationSeverity.Error
        };
    }
}