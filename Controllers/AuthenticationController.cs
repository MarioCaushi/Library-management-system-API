using Library_management_system_API.Dto;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticationDto loginRequest)
    {
        var loginData = await _authenticationService.Authenticate(loginRequest.Username, loginRequest.Password);
        
        if (loginData is null) return Unauthorized();
        return Ok(loginData);
    }
}