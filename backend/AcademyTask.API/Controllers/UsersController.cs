using AcademyTask.Application.DTO;
using AcademyTask.Application.Interfaces;
using AcademyTask.Application.Services;
using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace AcademyTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService  _userService;
    
    public UsersController(IUserService userService) =>  _userService = userService;

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var result = await _userService.RegisterAsync(request.Username, request.Password, request.Email);

        if (result.ValidationResult.HasErrors)
            return BadRequest(result.ValidationResult.ValidationItems);

        var user = result.Value!;

        var registeredUser = new UserResponseDto()
        {
            Email = user.Email,
            Id = user.Id,
            Username = user.Username
        };

        return Ok(registeredUser);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequestDto request)
    {
        var result = await _userService.LoginAsync(request.Username, request.Password);

        if (result.ValidationResult.HasErrors)
            return BadRequest(result.ValidationResult.ValidationItems);

        var token = result.Value!;
        
        return Ok(new { token });
    }
    
    
}