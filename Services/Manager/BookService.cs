using System.Runtime.Intrinsics.X86;
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
                IdOfLikeBook = bl.IdOfLikeB,
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
               ReviewId = r.IdOfReview,
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

    public async Task<ICollection<BookReviewsDto>> searchBookReviews(string keyword, int id)
    {
        int keywordAsInt;
        bool isInt = int.TryParse(keyword, out keywordAsInt);
        
        
        // Retrieve all reviews and associated client details in a single query
        return await _libraryDB.Reviews
            .Where(r => r.IdBook == id)
            .Select(r => new BookReviewsDto() 
            {
                ClientId =  r.IdClient,
                Review =  r.ReviewText,
                ReviewId = r.IdOfReview,
                Name = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == r.IdClient).Name,
                Username = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == r.IdClient).Username
            }).Where(dto =>  (isInt && dto.ClientId == keywordAsInt) ||
                            dto.Username.ToLower().Trim().Contains(keyword) ||
                            dto.Name.ToLower().Trim().Contains(keyword) ||
                            dto.Review.ToLower().Trim().Contains(keyword) ||
                            string.IsNullOrEmpty(keyword)).ToListAsync();
        
    }

    public async Task<ICollection<BookLikesDto>> searchBookLikes(string keyword, int id)
    {
        int keywordAsInt;
        bool isInt = int.TryParse(keyword, out keywordAsInt);

        return await _libraryDB.BooksLikes
            .Where(bl => bl.IdBook == id)
            .Select(bl => new BookLikesDto()
            {
                ClientId = bl.IdClient,
                IdOfLikeBook = bl.IdOfLikeB,
                Name = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == bl.IdClient).Name,
                Username = _libraryDB.Clients.FirstOrDefault(c => c.IdClient == bl.IdClient).Username,
            }).Where(dto => string.IsNullOrEmpty(keyword) || dto.Name.ToLower().Trim().Contains(keyword)
                                                          || dto.Username.ToLower().Trim().Contains(keyword) ||
                                                          (isInt && dto.ClientId == keywordAsInt)).ToListAsync();
    }

    public async Task<bool> editBook(EditBookDto book)
    {
        var bookToEdit = _libraryDB.Books.FirstOrDefault(b => b.IdBook == book.IdBook);
        if (bookToEdit == null) return false;
        
        bookToEdit.Title = book.Title;
        bookToEdit.Author = book.Author;
        bookToEdit.Genre = book.Genre;
        bookToEdit.Price = book.Price;
        bookToEdit.Description = book.Description;
        bookToEdit.PublishedYear = book.PublishedYear;
        bookToEdit.Rating = book.Rating;
        bookToEdit.CoverImageUrl = book.CoverImageUrl;
        bookToEdit.IdManager = book.IdManager;
        
        _libraryDB.Books.Update(bookToEdit);
        await _libraryDB.SaveChangesAsync();
        return true;
    }

    public async Task<bool> deleteEditBook(int id, string keyword)
    {
        if (keyword == "client")
        {
            var client = await _libraryDB.BooksLikes.FirstOrDefaultAsync(c => c.IdOfLikeB == id);
            if (client == null) return false;
            _libraryDB.BooksLikes.Remove(client);
            await _libraryDB.SaveChangesAsync();
            return true;
        }
        else
        {
            var review = await _libraryDB.Reviews.FirstOrDefaultAsync(b => b.IdOfReview == id);
            if (review == null) return false;
            _libraryDB.Reviews.Remove(review);
            await _libraryDB.SaveChangesAsync();
            return true;
        }
    }

}