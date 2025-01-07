namespace Library_management_system_API.Models;

// The books in a cart
public class CartBooks
{
    public int CartBooksId { get; set; }

    // Foreign Keys
    public int CartId { get; set; }
    public Cart Cart { get; set; }

    public int IdBook { get; set; }
    public Book Book { get; set; }
}