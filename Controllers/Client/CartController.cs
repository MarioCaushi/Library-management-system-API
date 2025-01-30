using System.Net;
using Library_management_system_API.Dto.Client;
using Library_management_system_API.Services.ServicesInterfaces.Client;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers.Client;

[ApiController]
[Route("[controller]")]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("client/{clientId}/add-purchase/{bookId}")]
    public async Task<IActionResult> AddBookPurchaseToClient([FromBody] BookPurchasedDto bookPurchasedDto)
    {
        var added = await _cartService.AddPurchaseToClient(bookPurchasedDto);
        if (added == false) return BadRequest();
        return Ok();
    }
}