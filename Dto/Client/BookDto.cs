using Library_management_system_API.Models;

namespace Library_management_system_API.Dto.Client;

public class BookDto
{
    public int IdBook { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    
    public string? Genre { get; set; }
    
    public string? Description { get; set; }
    
    public int? PublishedYear { get; set; }
    public string? CoverImageUrl { get; set; }
    public double? Price { get; set; }
    public double? Rating { get; set; }

    public int Likes { get; set; }

}