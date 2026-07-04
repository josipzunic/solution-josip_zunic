namespace AcademyTask.Application.DTO;

public class ProductResponseDto
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public string? ImageUrl { get; init; }

    public static string TruncateDescription(string? description)
    {
        if (string.IsNullOrEmpty(description))  return String.Empty;

        return description.Length <= 100
            ? description
            : description.Substring(0, 100);
        
    }
}