using Library_management_system_API.Dto;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : Controller
{
    private readonly IRegisterService _registerService;

    public RegisterController(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> register([FromBody] RegisterDto registerDto)
    {
        var registered = await _registerService.registerUser(registerDto);

        if (registered)
        {
            return Ok("User registerd successfully");
        }
            return BadRequest("User not registered");
    }

    [HttpPost("check-validity")]
    public async Task<IActionResult> checkValidity([FromBody] ValidityCheckUserDto input)
    {
        if(input is null) return BadRequest("Invalid input");
        
        var valid = await _registerService.checkValidity(input);
        
        if(valid) return Ok();
        
        return BadRequest("Not unique");
    }
    
}