namespace AcademyTask.Application.DTO;

public class RegisterRequestDTO
{
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
}