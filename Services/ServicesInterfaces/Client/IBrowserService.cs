namespace Library_management_system_API.Services.ServicesInterfaces.Client;
using Library_management_system_API.Dto.Client;

public interface IBrowserService
{
    public Task<ICollection<BookDto>> GetAllBooks();
    public Task<BookDto> GetBookById(int id);
    public Task<ICollection<BookReviewDto>> GetAllBookReviews(int id);
    public Task<bool> AddBookReview(AddReviewDto reviewDto);
    public Task<UserDto> GetClientById(int id);
    public Task<ICollection<BookLikeDto>> GetLikesByBookID(int booksId, int clientId);
    
    public Task<bool> AddLikeToBookAndClient(int clientId, int bookId);
}