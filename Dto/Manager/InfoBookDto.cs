namespace Library_management_system_API.Dto.Manager;

public class InfoBookDto
{
    public int BookId { get; set; }
    
    public string CoverImageUrl { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublishedYear { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
    
    public int NoLikes { get; set; }
    public int NoReviews { get; set; }
    
    public ICollection<BookLikesDto> BookLikes { get; set; }
    public ICollection<BookReviewsDto> BookReviews { get; set; }
}