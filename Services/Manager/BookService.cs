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

    public async Task<ICollection<BookCardDto>> searchBookCards(string keyword)
    {
        int keywordAsInt;
        double keywordAsDouble;
        bool isInt = int.TryParse(keyword, out keywordAsInt);
        bool isDouble = double.TryParse(keyword, out keywordAsDouble);

        var books = await _libraryDB.Books
            .Where(book => 
                string.IsNullOrEmpty(keyword) ||
                book.Title.Trim().ToLower().Contains(keyword.Trim().ToLower()) ||
                book.Author.Trim().ToLower().Contains(keyword.Trim().ToLower()) ||
                book.Genre.Trim().ToLower().Contains(keyword.Trim().ToLower()) ||
                (isDouble && book.Price == keywordAsDouble) ||
                (isInt && book.IdBook == keywordAsInt))
            .Select(book => new BookCardDto
            {
                IdBook = book.IdBook,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price,
                CoverImageUrl = book.CoverImageUrl,
            })
            .ToListAsync();

        return books;
    }

    public async Task<InfoBookDto?> getBookInfo(int id)
    {
        var book = await _libraryDB.Books
            .FirstOrDefaultAsync(b => b.IdBook == id);
        if (book == null) return null;

        // Retrieve all clients associated with the likes in a single query
        var bookLikes = await _libraryDB.BooksLikes
            .Where(bl => bl.IdBook == id)
            .Select(bl => new BookLikesDto()
            {
                ClientId = bl.IdClient,
                Name = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == bl.IdClient).Name,
                Username = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == bl.IdClient).Username,
            }).ToListAsync();

        // Retrieve all reviews and associated client details in a single query
        var bookReviews = await _libraryDB.Reviews
            .Where(r => r.IdBook == id)
            .Select(r => new BookReviewsDto() 
            {
               ClientId =  r.IdClient,
               Review =  r.ReviewText,
               Name = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == r.IdClient).Name,
               Username = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == r.IdClient).Username
            }).ToListAsync();

        return new InfoBookDto
        {
            BookId = id,
            CoverImageUrl = book.CoverImageUrl,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Description = book.Description,
            PublishedYear = book.PublishedYear,
            Rating = book.Rating,
            NoLikes = bookLikes.Count,
            NoReviews = bookReviews.Count,
            BookReviews = bookReviews,
            BookLikes = bookLikes
        };
    }




    
    
}