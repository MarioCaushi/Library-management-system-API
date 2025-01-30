using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces.Client;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services.Client;
using Library_management_system_API.Data;
using Library_management_system_API.Dto.Client;

public class BrowserService : IBrowserService
{
    private readonly LibraryDB _libraryDb;

    public BrowserService(LibraryDB libraryDb)
    {
        _libraryDb = libraryDb;
    }

    public async Task<ICollection<BookDto>> GetAllBooks()
    {
        return await _libraryDb.Books.Select(book => new BookDto
        {
            IdBook = book.IdBook,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            CoverImageUrl = book.CoverImageUrl,
            PublishedYear = book.PublishedYear,
            Rating = book.Rating,
            Description = book.Description,
            Genre = book.Genre,
            Likes = _libraryDb.BooksLikes.Count(b => b.IdBook == book.IdBook),
        }).ToListAsync();
    }

    public async Task<BookDto> GetBookById(int id)
    {
        int likes = _libraryDb.BooksLikes.Count(b => b.IdBook == id);
        var book =  await _libraryDb.Books.FirstOrDefaultAsync(book => book.IdBook == id);
        return new BookDto
        {
            IdBook = book.IdBook,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            CoverImageUrl = book.CoverImageUrl,
            PublishedYear = book.PublishedYear,
            Rating = book.Rating,
            Description = book.Description,
            Genre = book.Genre,
            Likes = likes
        };
    }

    public async Task<ICollection<BookReviewDto>> GetAllBookReviews(int id)
    {
        var bookReviews = await _libraryDb.Reviews
            .Where(bookReview => bookReview.IdBook == id)
            .Select(bookReview => new BookReviewDto()
            {
                ClientId = bookReview.IdClient,
                Review = bookReview.ReviewText,
                ReviewId = bookReview.IdOfReview,
                Name = _libraryDb.Clients.FirstOrDefault(client => client.IdClient == bookReview.IdClient).Name,
                Username = _libraryDb.Clients.FirstOrDefault(client => client.IdClient == bookReview.IdClient).Username,
            }).ToListAsync();
        return bookReviews;
    }

    public async Task<bool> AddBookReview(AddReviewDto reviewDto)
    {
        if (reviewDto == null) return false;
        Review review = new Review()
        {
            IdOfReview = new Random().Next(10,100),
            ReviewText = reviewDto.ReviewText,
            IdClient = reviewDto.IdClient,
            Client = _libraryDb.Clients.FirstOrDefault(client => client.IdClient == reviewDto.IdClient),
            IdBook = reviewDto.IdBook,
            Book = _libraryDb.Books.FirstOrDefault(book => book.IdBook == reviewDto.IdBook),
        };
        _libraryDb.Reviews.Add(review);
        await _libraryDb.SaveChangesAsync();
        return true;
    }
    public async Task<UserDto> GetClientById(int id)
    {
        var user = await  _libraryDb.Clients.FirstOrDefaultAsync(client => client.IdClient == id);
        return new UserDto()
        {
            IdClient = user.IdClient,
            Name = user.Name,
            Surname = user.LastName,
            Username = user.Username,
            Email = user.Email,
            Birthday = user.Birthday,
            Password = user.Password
        };
    }

    public async Task<ICollection<BookLikeDto>> GetLikesByBookID(int booksId, int clientId)
    {
        var bookLikes = await _libraryDb.BooksLikes
            .Where(book => book.IdBook == booksId && book.IdClient == clientId)
            .Select(book => new BookLikeDto()
            {
                IdBook = book.IdBook,
                IdClient = book.IdClient,
                IdOfLikeB = book.IdOfLikeB,
            }).ToListAsync();
        return bookLikes;
    }

    public async Task<bool> AddLikeToBookAndClient(int clientId, int bookId)
    {   
        BooksLikes bookLike = new BooksLikes()
        {
            IdBook = bookId,
            Book = _libraryDb.Books.FirstOrDefault(book => book.IdBook == bookId),
            IdClient = clientId,
            Client = _libraryDb.Clients.FirstOrDefault(client => client.IdClient == clientId),
        };
        _libraryDb.BooksLikes.Add(bookLike);
        await _libraryDb.SaveChangesAsync();

        ClientLiked clientLike= new ClientLiked()
        {
            IdClient = clientId,
            Client = _libraryDb.Clients.FirstOrDefault(client => client.IdClient == clientId),
            IdBook = bookId,
            Book = _libraryDb.Books.FirstOrDefault(book => book.IdBook == bookId),
        };
        _libraryDb.ClientLikes.Add(clientLike);
        await _libraryDb.SaveChangesAsync();

        return true;

    }

    
    
}