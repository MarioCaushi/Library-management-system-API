namespace Library_management_system_API.Dto.Manager;

public class BookCardDto
{
    public int IdBook { get; set; } 
    
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public double Price { get; set; }
    
    public string CoverImageUrl { get; set; }
}