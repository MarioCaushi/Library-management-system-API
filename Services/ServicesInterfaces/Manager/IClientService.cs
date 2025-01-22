using Library_management_system_API.Dto.Manager;

namespace Library_management_system_API.Services.ServicesInterfaces
{
    public interface IClientService
    {
        public Task<ICollection<ClientsDto?>> GetAllClients();
        public Task<bool> DeleteClient(int clientId);

        public Task<IEnumerable<ClientsDto>> SearchClientAsync(string query);

        public Task<ClientInfoDto> GetClientInfo(int clientId);

        public Task<ICollection<ClientBookDto>> GetPurchasedBooks(int clientId);

        public Task<ICollection<ClientBookDto>> GetLikedBooks(int clientId);

        public Task<ICollection<ClientReviewDto>> GetClientReviews(int clientId);

        public Task<bool> EditClientInfo(int clientId, ClientInfoDto updatedClientInfo);

        public Task<bool> DeleteBookLike(int clientId, int bookId);

        public Task<bool> DeleteBookReview(int clientId, int reviewId);
        
    }
}
