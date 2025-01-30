using Library_management_system_API.Data;
using Library_management_system_API.Dto;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services;

public class RegisterService: IRegisterService
{
    private readonly LibraryDB _libraryDB;

    public RegisterService(LibraryDB libraryDB)
    {
        _libraryDB = libraryDB;
    }

    public async Task<bool> registerUser(RegisterDto? input)
    {
        if (input is null) return false;
        
        var newClient = new Models.Client()
        {
            Name = input.Name,
            LastName = input.LastName,
            Email = input.Email,
            Birthday = input.Birthday,
            Username = input.Username,
            Password = input.Password,
            IdManager = input.IdManager,
        };
        
        await _libraryDB.Clients.AddAsync(newClient);
        await _libraryDB.SaveChangesAsync();
        return true;
    }

    public async Task<bool> checkValidity(ValidityCheckUserDto input)
    {
        bool valid = true;
        
        if (input.Type == "Email")
        {
            var user = await _libraryDB.Clients.FirstOrDefaultAsync(m => m.Email == input.Content);
            
            if(user != null) valid = false;
        }
        else
        {
            var user = await _libraryDB.Clients.FirstOrDefaultAsync(m => m.Username == input.Content);
            
            if(user != null) valid = false;
        }
        
        return valid;
    }

}