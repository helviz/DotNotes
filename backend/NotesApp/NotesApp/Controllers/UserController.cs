using Microsoft.AspNetCore.Mvc;
using NotesApp.DTO.UserDTO;
using NotesApp.Models;
using NotesApp.Service;

namespace NotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDTO dto)
    {
        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = dto.Password
        };
        var createdUser = await _userService.CreateAsync(user);
        return Ok(ToResponseDto(createdUser));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        
        return Ok(ToResponseDto(user));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateDTO dto)
    {
        var user = new User
        {
            Id = dto.Id,
            UserName = dto.UserName,
            Email = dto.Email
        };

        var updateduser = await _userService.UpdateAsync(user);
        return Ok(ToResponseDto(updateduser));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var user = await _userService.AuthenticateAsync(dto.Email, dto.Password);
        
        return Ok(ToResponseDto(user));

    }

    private static UserResponseDTO ToResponseDto(User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            IsActive = user.isActive
        };
    }
}