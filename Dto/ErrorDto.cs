using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library_management_system_API.Dto;

public class ErrorDto
{
    public int StatusCode { get; set; }
    
    public string Message { get; set; }
    
    public string Path { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}