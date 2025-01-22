namespace Library_management_system_API.Dto;

public class ValidityCheckUserDto
{
    //Type can be: Email / Username
    public string Type { get; set; }
    
    //Content is the actual content of an email / username
    public string Content { get; set; }
}