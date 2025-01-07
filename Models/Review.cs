namespace Library_management_system_API.Models;

public class Review
{
    public int IdOfReview { get; set; }
    
    public string ReviewText { get; set; }

    // Foreign Keys
    public int IdClient { get; set; }
    public Client Client { get; set; }

    public int IdBook { get; set; }
    public Book Book { get; set; }
}