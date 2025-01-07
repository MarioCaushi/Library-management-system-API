namespace Library_management_system_API.Models;

// Which books a client liked

public class ClientLiked
{
    public int IdOfLike { get; set; }

    // Foreign Keys
    public int IdClient { get; set; }
    public Client Client { get; set; }

    public int IdBook { get; set; }
    public Book Book { get; set; }
}