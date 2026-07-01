using System.Text.Json.Serialization;

namespace AcademyTask.Domain.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValidationSeverity
{
    Error,
    Warning,
    Info,
}