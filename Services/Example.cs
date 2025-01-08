using Library_management_system_API.Data;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services;

public class Example : IExample
{
    private readonly LibraryDB _libraryDB;
    
    public Example(LibraryDB libraryDB)
    {
        _libraryDB = libraryDB;
    }

    public async Task<ICollection<Book?>> GetBooks()
    {
        return await _libraryDB.Books.ToListAsync();
    }

}