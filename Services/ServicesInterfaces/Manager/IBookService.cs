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
}