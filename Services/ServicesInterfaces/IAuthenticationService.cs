namespace Library_management_system_API.Services.ServicesInterfaces;

public interface IAuthenticationService
{
    //Method to return authentication info if not null
    public Task<Dictionary<string, string>?> Authenticate(string username, string password);
}