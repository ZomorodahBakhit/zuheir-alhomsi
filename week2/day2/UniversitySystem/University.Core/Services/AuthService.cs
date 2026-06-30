using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using University.Core.DTOs;
using University.Core.Exceptions;
using University.Core.Forms.AuthForm;
using University.Core.Validation;
using University.Data.Entities;

namespace University.Core.Services;

public interface IAuthService
{
    Task<UserDto> Login(LoginForm form);
    Task<UserDto> Register(RegisterForm form);
}

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        ILogger<AuthService> logger,
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<UserDto> Register(RegisterForm form)
    {
        var validation = FormValidator.Validate(form);
        if (!validation.IsValid) throw new BusinessException("Invalid form data");

        var userExists = await _userManager.FindByEmailAsync(form.Email);
        if (userExists != null) throw new BusinessException("User already exists with this email");

        var user = new User
        {
            Email = form.Email,
            UserName = form.Email,
        };

        var result = await _userManager.CreateAsync(user, form.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BusinessException($"User creation failed: {errors}");
        }

        if (!await _roleManager.RoleExistsAsync(form.Role))
        {
            throw new BusinessException("Invalid role");
        }
        await _userManager.AddToRoleAsync(user, form.Role);

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = form.Role
        };
    }

    public async Task<UserDto> Login(LoginForm form)
    {
        var user = await _userManager.FindByEmailAsync(form.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, form.Password))
        {
            throw new BusinessException("Invalid credentials");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "Student";

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = role
        };
    }
}