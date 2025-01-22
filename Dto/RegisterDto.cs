namespace Library_management_system_API.Dto;

public class RegisterDto
{
    public string Name { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public int IdManager { get; set; }
}