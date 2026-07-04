namespace AcademyTask.Application.DTO;

public class LikedProductResponse
{
    public int UserId { get; init; }
    public int ProductId { get; init; }
    public string ProductName { get; init; } = null!;
}