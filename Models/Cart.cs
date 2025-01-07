namespace Library_management_system_API.Models;

// The shopping cart
public class Cart
{
    public int CartId { get; set; }

    // Foreign Key
    public int IdClient { get; set; }
    public Client? Client { get; set; }

    // Navigation Properties
    public ICollection<CartBooks> CartBooks { get; set; }
}