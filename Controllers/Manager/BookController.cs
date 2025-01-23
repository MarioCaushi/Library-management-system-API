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

        if (exists) return Ok("Book exists"); 
        return NotFound("Book does not exist");
    }


    [HttpPost("add-book")]
    public async Task<IActionResult> AddBook([FromBody] AddBookDto? addBook)
    {
     if (addBook == null) return NoContent();
     
     var added = await _bookService.addBook(addBook);
     
     if (added == false) return BadRequest();
     
     return Ok("Book added");
    }

    [HttpGet("search-books/{keyword}")]
    public async Task<IActionResult> SearchBooks(string keyword)
    {
        var searchBooks = await _bookService.searchBookCards(keyword);
        
        if (searchBooks == null || searchBooks.Count == 0) return NoContent();
        return Ok(searchBooks);
    }

    [HttpGet("get-book-info/{id:int}")]
    public async Task<IActionResult> GetBookInfo(int id)
    {
        var bookInfo = await _bookService.getBookInfo(id);
        if (bookInfo == null) return NoContent();
        return Ok(bookInfo);
    }

    [HttpGet("search-book-reviews/{id:int}/{keyword}")]
    public async Task<IActionResult> SearchBookReviews(int id, string keyword)
    {
        var searchReviews = await _bookService.searchBookReviews(keyword, id);
        if (searchReviews == null || searchReviews.Count == 0) return NoContent();
        return Ok(searchReviews);
    }

    [HttpGet("search-book-likes/{id:int}/{keyword}")]
    public async Task<IActionResult> SearchBookLikes(int id, string keyword)
    {
        var searchBookLikes = await _bookService.searchBookLikes(keyword, id);
        if (searchBookLikes == null || searchBookLikes.Count == 0) return NoContent();
        return Ok(searchBookLikes);
    }

    [HttpPut("update-book")]
    public async Task<IActionResult> updateBook([FromBody] EditBookDto? editBook)
    {
        if (editBook == null) return BadRequest();
        
        var isEdited = await  _bookService.editBook(editBook);
        if(!isEdited) return NoContent();
        return Ok();
    }
}