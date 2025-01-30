using Library_management_system_API.Dto.Client;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Services.ServicesInterfaces.Client;

public interface ICartService
{
   public Task<bool> AddPurchaseToClient(BookPurchasedDto bookPurchasedDto);
}