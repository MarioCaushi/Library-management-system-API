using Library_management_system_API.Controllers.Manager;
using Library_management_system_API.Dto.Client;
using Library_management_system_API.Services.Client;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces;
using Library_management_system_API.Services.ServicesInterfaces.Client;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers.Client;

[ApiController]
[Route("[controller]")]
public class BrowserController : Controller
{
    private readonly IBrowserService _browserService;

    public BrowserController(IBrowserService  browserService)
    {
        _browserService = browserService;
    }
    
    [HttpGet("books")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _browserService.GetAllBooks();
        return (books == null) ? NoContent() : Ok(books);
    }

    [HttpGet("books/{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _browserService.GetBookById(id);
        return (book == null) ? NoContent() : Ok(book);
    }

    [HttpGet("get-book-reviews/{id}")]
    public async Task<IActionResult> GetBookReviews(int id)
    {
        var bookReviews = await _browserService.GetAllBookReviews(id);
        return (bookReviews == null) ? NoContent() : Ok(bookReviews);

    }

    [HttpPost("client/{clientId}/add-review/{id}")]
    public async Task<IActionResult> AddBookReview([FromBody] AddReviewDto reviewDto)
    {
        var added = await _browserService.AddBookReview(reviewDto);
        if (added == false) return BadRequest();
        return Ok("Review added");
    }

    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var user = await  _browserService.GetClientById(clientId);
        return (user == null) ? NoContent() : Ok(user); 
    }

    [HttpGet("books/likes/{booksId}")]
    public async Task<IActionResult> GetLikes(int booksId, int clientId)
    {
        var likes = await _browserService.GetLikesByBookID(booksId, clientId);
        return Ok(likes.Count);
    }

    [HttpPost("client/{clientId}/books/{bookId}/add-like")]
    public async Task<IActionResult> AddLike(int clientId, int bookId)
    {
        var addedLike = await _browserService.AddLikeToBookAndClient(clientId, bookId);
        if (addedLike == false) return BadRequest();
        return Ok("Like Added");
    }
    
}