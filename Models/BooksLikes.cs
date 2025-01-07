namespace Library_management_system_API.Models;

// Which Client has liked which book
// The client likes a book has 
public class BooksLikes
{
    public int IdOfLikeB { get; set; }

    // Foreign Keys
    public int IdClient { get; set; }
    public Client Client { get; set; }

    public int IdBook { get; set; }
    public Book Book { get; set; }
}