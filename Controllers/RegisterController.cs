using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers;

public class RegisterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}