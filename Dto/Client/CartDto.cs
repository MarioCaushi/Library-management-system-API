using Library_management_system_API.Models;

namespace Library_management_system_API.Dto.Client;

public class CartDto
{
    public int CartId { get; set; }
    public int IdClient { get; set; }
    public Array CartBooks { get; set; } 
}