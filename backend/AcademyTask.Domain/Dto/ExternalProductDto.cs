namespace AcademyTask.Domain.Dto;

public class ExternalProductDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public List<string>? Images { get; init; }
    public decimal Price { get; init; }
    public required string Category { get; init; }
}