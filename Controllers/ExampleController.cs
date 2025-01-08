using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers;

[ Route( "api/[controller]" )]
[ ApiController]
public class ExampleController : Controller
{

    private readonly IExample _example;
    
    public ExampleController(IExample example)
    {
        _example = example;
    }

    [HttpGet("get-books")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _example.GetBooks());
    }
}