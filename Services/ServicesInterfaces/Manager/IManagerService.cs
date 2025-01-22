using Library_management_system_API.Dto.Manager;

namespace Library_management_system_API.Services.ServicesInterfaces
{
    public interface IManagerService
    {
        public Task<ManagerDto?> GetManagerInfo(int id);
    }

}
