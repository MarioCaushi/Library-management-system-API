using Library_management_system_API.Data;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly LibraryDB _libraryDB;

    public AuthenticationService(LibraryDB libraryDB)
    {
        _libraryDB = libraryDB;
    }

    public async Task<Dictionary<string, string>?> Authenticate(string username, string password)
    {
        // Check if the user is a manager
        var manager = await _libraryDB.Managers
            .FirstOrDefaultAsync(m => m.Username == username && m.Password == password);

        if (manager != null)
        {
            return new Dictionary<string, string> { { "Role", "Manager" }, { "Id", manager.IdManager.ToString() } };
        }

        // Check if the user is a client
        var client = await _libraryDB.Clients
            .FirstOrDefaultAsync(c => c.Username == username && c.Password == password);

        if (client != null)
        {
            return new Dictionary<string, string> { { "Role", "Client" }, { "Id", client.IdClient.ToString() } };
        }

        // Return null if no user found
        return null;
    }
}