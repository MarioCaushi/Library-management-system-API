using Library_management_system_API.Dto;

namespace Library_management_system_API.Services.ServicesInterfaces;

public interface IRegisterService
{
    //Method to register a new client
    public Task<bool> registerUser(RegisterDto? input);
    
    //Method to check if a username or email is unique
    public Task<bool> checkValidity(ValidityCheckUserDto input);
}