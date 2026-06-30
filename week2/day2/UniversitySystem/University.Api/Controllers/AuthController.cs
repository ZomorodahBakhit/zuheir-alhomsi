using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using University.Api.Filters;
using University.Api.Helpers;
using University.Core.Forms.AuthForm;
using University.Core.Services;

namespace University.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[TypeFilter(typeof(ApiExceptionFilter))]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenHelper _jwtTokenService;
    private readonly IAuthService _authService;

    public AuthController(IJwtTokenHelper jwtTokenHelper, IAuthService authService)
    {
        _jwtTokenService = jwtTokenHelper;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ApiResponse> Register([FromBody] RegisterForm form)
    {
        var dto = await _authService.Register(form);
        return new ApiResponse("User registered successfully", dto);
    }

    [HttpPost("login")]
    public async Task<ApiResponse> Login([FromBody] LoginForm form)
    {
        var user = await _authService.Login(form);
        var token = _jwtTokenService.GenerateToken(user);
        return new ApiResponse("Login successful", token);
    }

    [Authorize]
    [HttpGet("me")]
    public ApiResponse GetMyInfo()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = User.FindFirstValue(ClaimTypes.Email);
        var role = User.FindFirstValue(ClaimTypes.Role);

        var logger = HttpContext.RequestServices.GetRequiredService<ILogger<AuthController>>();
        logger.LogInformation("User accessed /me: ID={Id}, Role={Role}, Email={Email}", userId, role, email);

        return new ApiResponse("User identity info retrieved", new
        {
            Id = userId,
            Email = email,
            Role = role
        });
    }
}