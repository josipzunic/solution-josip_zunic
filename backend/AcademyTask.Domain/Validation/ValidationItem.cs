using AcademyTask.Domain.Enums;

namespace AcademyTask.Domain.Validation;

public class ValidationItem
{
    public ValidationSeverity  ValidationSeverity { get; set; }
    public ValidationType ValidationType { get; set; }
    public required string Code { get; init; }
    public required string Message { get; init; }
}