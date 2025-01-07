namespace Library_management_system_API.Models;

// The books a client has purchased
public class BooksPurchased
{
    public int IdOfPurchase { get; set; }

    // Foreign Keys
    public int IdClient { get; set; }
    public Client Client { get; set; }

    public int IdBook { get; set; }
    public Book Book { get; set; }
}