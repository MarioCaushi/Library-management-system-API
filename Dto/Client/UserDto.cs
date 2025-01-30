namespace Library_management_system_API.Dto.Client;

public class UserDto
{
    public int IdClient { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Username { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    
    public string Password { get; set; }
    
}
