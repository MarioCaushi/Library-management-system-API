namespace Library_management_system_API.Models;

public class Manager
{
    public int IdManager { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    // Navigation Properties
    public ICollection<Book> Books { get; set; }
    public ICollection<Client> Clients { get; set; }
}