namespace Library_management_system_API.Models;

public class Client
{
    public int IdClient { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    // Foreign Key
    public int IdManager { get; set; }
    public Manager Manager { get; set; }

    // Navigation Properties
    public Cart Cart { get; set; }
    public ICollection<ClientLiked> ClientLikes { get; set; }
    public ICollection<BooksPurchased> BooksPurchased { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<BooksLikes> BooksLikes { get; set; }
}