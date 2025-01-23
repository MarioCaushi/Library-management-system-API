using Library_management_system_API.Dto.Manager;


namespace Library_management_system_API.Services.ServicesInterfaces;

public interface IBookService
{
    //Function to show all book cards of a manager
    public Task<ICollection<BookCardDto>> getAllBookCards();
    
    //Function to delete a book
    public Task<bool> deleteBook(int id);
    
    //Function to check book uniqueness by its title
    public Task<bool> checkBookExists(string title);
    
    //Function to add a new book
    public Task<bool> addBook(AddBookDto book);
    
    //Function to get books by keyword
    public Task<ICollection<BookCardDto>> searchBookCards(string keyword);
    
    //Function to get the necessary book info
    public Task<InfoBookDto?> getBookInfo(int id);
    
    //Function to search the reviews of a book
    public Task<ICollection<BookReviewsDto>> searchBookReviews(string keyword,int id);
    
    //Function to search the likes list of a book
    public Task<ICollection<BookLikesDto>> searchBookLikes(string keyword,int id);
    
    //Function to edit book info 
    public Task<bool> editBook(EditBookDto book);
    
    //Function to delete a review or a like from a book
    public Task<bool> deleteEditBook(int id, string keyword);

}