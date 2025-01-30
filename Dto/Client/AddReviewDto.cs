using Library_management_system_API.Models;

namespace Library_management_system_API.Dto.Client;

public class AddReviewDto
{
    public string ReviewText { get; set; }
    public int IdClient { get; set; }
    public int IdBook { get; set; }

}