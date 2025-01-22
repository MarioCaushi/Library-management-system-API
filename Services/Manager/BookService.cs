using Library_management_system_API.Data;
using Library_management_system_API.Dto.Manager;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services.Manager;

public class BookService : IBookService
{
    private readonly LibraryDB _libraryDB;

    public BookService(LibraryDB libraryDB)
    {
        _libraryDB = libraryDB;
    }

    public async Task<ICollection<BookCardDto>> getAllBookCards()
    {
        return await _libraryDB.Books.Select(book => new BookCardDto
        {
            IdBook = book.IdBook,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            CoverImageUrl = book.CoverImageUrl,
        }).ToListAsync();
    }

    public async Task<bool> deleteBook(int id)
    {
        var book = await _libraryDB.Books.FirstOrDefaultAsync(book => book.IdBook == id);
        
        if (book == null) return false;
        
        _libraryDB.Books.Remove(book);
        await _libraryDB.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> checkBookExists(string title)
    {
        return await _libraryDB.Books.AnyAsync(book => 
            book.Title.Trim().ToLower() == title.Trim().ToLower()
        );
    }

    public async Task<bool> addBook(AddBookDto? book)
    {
        if(book == null) return false;
        
        var newBook = new Book()
        {
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            CoverImageUrl = book.CoverImageUrl,
            Rating = book.Rating,
            Description = book.Description,
            PublishedYear = book.PublishedYear,
            IdManager = book.IdManager,
        };
        
        _libraryDB.Books.Add(newBook);
        await _libraryDB.SaveChangesAsync();
        return true;
    }

}