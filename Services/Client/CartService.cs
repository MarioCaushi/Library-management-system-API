using Library_management_system_API.Data;
using Library_management_system_API.Dto.Client;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services.Client;

public class CartService : ICartService
{
    private readonly LibraryDB _libraryDb;

    public CartService(LibraryDB libraryDb)
    {
        _libraryDb = libraryDb;
    }

    public async Task<bool> AddPurchaseToClient(BookPurchasedDto bookPurchasedDto)
    {
        if (bookPurchasedDto == null) return false;
        BooksPurchased booksPurchased = new BooksPurchased()
        {
            IdClient = bookPurchasedDto.IdClient,
            Client = await _libraryDb.Clients.FirstOrDefaultAsync(c => c.IdClient == bookPurchasedDto.IdClient),
            IdBook = bookPurchasedDto.IdBook,
            Book = await _libraryDb.Books.FirstOrDefaultAsync(b => b.IdBook == bookPurchasedDto.IdBook)
        };
        _libraryDb.BooksPurchased.Add(booksPurchased);
        await _libraryDb.SaveChangesAsync();
        return true;
    }
    
    
}