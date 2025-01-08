using Library_management_system_API.Models;

namespace Library_management_system_API.Services.ServicesInterfaces;

public interface IExample
{
    public Task<ICollection<Book?>> GetBooks();
}