using AcademyTask.Domain.Enums;

namespace AcademyTask.Domain.Validation;

public class ValidationResult
{
    private List<ValidationItem> _validationItems = new ();
    public IReadOnlyList<ValidationItem> ValidationItems => _validationItems;

    public bool HasErrors => _validationItems.Any(item => item.ValidationSeverity == ValidationSeverity.Error);
    public bool HasWarnings => _validationItems.Any(item => item.ValidationSeverity == ValidationSeverity.Warning);
    public bool HasInfo => _validationItems.Any(item => item.ValidationSeverity == ValidationSeverity.Info);
    
    public void AddValidationItems(ValidationItem validationItem) =>  _validationItems.Add(validationItem);
}