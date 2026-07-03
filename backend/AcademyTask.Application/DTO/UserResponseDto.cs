namespace AcademyTask.Application.DTO;

public class UserResponseDto
{
    public int Id { get; init; }
    public string Username { get; init; } = null!;
    public string Email { get; init; } = null!;
}