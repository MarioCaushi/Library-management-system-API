using Library_management_system_API.Data;
using Library_management_system_API.Dto.Manager;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services.Manager
{
    public class ManagerService : IManagerService
    {
        private readonly LibraryDB _libraryDB;

        public ManagerService(LibraryDB libraryDB)
        {
            _libraryDB = libraryDB;
        }

        public async Task<ManagerDto?> GetManagerInfo(int id)
        {
            var manager = await _libraryDB.Managers.FirstOrDefaultAsync(m => m.IdManager == id);

            if (manager == null)
            {
                return null;
            }
            var totalBooks = await _libraryDB.Books.ToListAsync();

            var totalClients = await _libraryDB.Clients.ToListAsync();

            var managerDto = new ManagerDto()
            {
                Id = manager.IdManager,
                Name = manager.Name,
                LastName = manager.LastName,
                Email = manager.Email,
                Birthday = manager.Birthday,
                Username = manager.Username,
                TotalBooks = totalBooks.Count,
                TotalClients = totalClients.Count,
            };

            return managerDto;
        }
    }
}
