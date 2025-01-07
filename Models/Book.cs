namespace Library_management_system_API.Models;

public class Book
{
    public int IdBook { get; set; } 
    
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublishedYear { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string CoverImageUrl { get; set; }
    public double Rating { get; set; }

    // Foreign Key
    public int IdManager { get; set; }
    public Manager Manager { get; set; }

    // Navigation Properties
    public ICollection<ClientLiked> ClientLikes { get; set; }
    public ICollection<BooksPurchased> BooksPurchased { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<BooksLikes> BooksLikes { get; set; }
    public ICollection<CartBooks> CartBooks { get; set; }
}