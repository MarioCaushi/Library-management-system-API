using Library_management_system_API.Dto.Manager;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers.Manager;

[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("get-book-cards")]
    public async Task<IActionResult> GetBookCards()
    {
        var bookCards = await _bookService.getAllBookCards();
        
        if (bookCards == null) return NoContent();
        return Ok(bookCards);
    }

    [HttpDelete("delete-book/{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _bookService.deleteBook(id);

        if (deleted == null) return NoContent();

        return Ok(); 
    }

    [HttpGet("check-book/{title}")]
    public async Task<IActionResult> CheckBook(string title)
    {
        var exists = await _bookService.checkBookExists(title);
        
        if (exists) return NoContent();
        
        return Ok("Book does not exist");
    }

    [HttpPost("add-book")]
    public async Task<IActionResult> AddBook([FromBody] AddBookDto? addBook)
    {
     if (addBook == null) return NoContent();
     
     var added = await _bookService.addBook(addBook);
     
     if (added == false) return BadRequest();
     
     return Ok("Book added");
    }
}