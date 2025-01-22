using System;
using Library_management_system_API.Data;
using Library_management_system_API.Dto.Manager;
using Library_management_system_API.Models;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_management_system_API.Services.Manager
{
    public class ClientsService : IClientService
    {
        private readonly LibraryDB _libraryDB;

        public ClientsService(LibraryDB libraryDB)
        {
            _libraryDB = libraryDB;
        }

        public async Task<ICollection<ClientsDto?>> GetAllClients()
        {
            return await _libraryDB.Clients
            .Select(client => new ClientsDto
            {
                Id = client.IdClient,
                Name = client.Name,
                LastName = client.LastName,
                Username = client.Username,

                // Aggregate counts from the relationship tables
                BooksLiked = _libraryDB.ClientLikes.Count(bl => bl.IdClient == client.IdClient),
                BooksPurchased = _libraryDB.BooksPurchased.Count(bp => bp.IdClient == client.IdClient)
            })
            .ToListAsync();
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            var client = await _libraryDB.Clients.FindAsync(clientId);
            if (client == null)
            {
                return false;
            }

            _libraryDB.Clients.Remove(client);
            await _libraryDB.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClientsDto>> SearchClientAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Enumerable.Empty<ClientsDto>();
            }

            return await _libraryDB.Clients
                .Where(client => EF.Functions.Like(client.Name, $"%{query}%") ||
                         EF.Functions.Like(client.LastName, $"%{query}%") ||
                         EF.Functions.Like(client.Username, $"%{query}%"))
                .Select(client => new ClientsDto
                {
                    Id = client.IdClient,
                    Name = client.Name,
                    LastName = client.LastName,
                    Username = client.Username,

                    BooksLiked = _libraryDB.ClientLikes.Count(bl => bl.IdClient == client.IdClient),
                    BooksPurchased = _libraryDB.BooksPurchased.Count(bp => bp.IdClient == client.IdClient)
                })
                .ToListAsync();
        }


        public async Task<ClientInfoDto> GetClientInfo(int clientId)
        {
            var client = await _libraryDB.Clients
            .Where(c => c.IdClient == clientId)
            .Select(c => new ClientInfoDto
            {
                Id = c.IdClient,
                Name = c.Name,
                LastName = c.LastName,
                Email = c.Email,
                Birthday = c.Birthday.ToString("yyyy-MM-dd"),
                Username = c.Username,
                Password = c.Password
            })
            .FirstOrDefaultAsync();

            return client;
        }


        public async Task<ICollection<ClientBookDto>> GetPurchasedBooks(int clientId)
        {
            var purchasedBooks = await _libraryDB.BooksPurchased
                .Where(bp => bp.IdClient == clientId)
                .Select(bp => new ClientBookDto
                {
                    BookId = bp.Book.IdBook,
                    Title = bp.Book.Title,
                    Author = bp.Book.Author,
                    URL = bp.Book.CoverImageUrl
                })
                .ToListAsync();


            return purchasedBooks ?? new List<ClientBookDto>();
        }

        public async Task<ICollection<ClientBookDto>> GetLikedBooks(int clientId)
        {
            var likedBooks = await _libraryDB.ClientLikes
            .Where(bl => bl.IdClient == clientId)
            .Select(bl => new ClientBookDto
            {
                BookId = bl.Book.IdBook,
                Title = bl.Book.Title,
                Author = bl.Book.Author,
                URL = bl.Book.CoverImageUrl
            })
            .ToListAsync();


            return likedBooks ?? new List<ClientBookDto>();

        }

        public async Task<ICollection<ClientReviewDto>> GetClientReviews(int clientId)
        {
            var reviews = await _libraryDB.Reviews
            .Where(r => r.IdClient == clientId)
            .Select(r => new ClientReviewDto
            {
                IdOfReview = r.IdOfReview,
                BookTitle = r.Book.Title,
                Author = r.Book.Author,
                ReviewText = r.ReviewText,
            })
            .ToListAsync();


            return reviews ?? new List<ClientReviewDto>();
        }


        public async Task<bool> EditClientInfo(int clientId, ClientInfoDto updatedClientInfo)
        {
            var client = await _libraryDB.Clients
                .FirstOrDefaultAsync(c => c.IdClient == clientId);

            if (client == null)
            {
                return false;
            }

            client.Name = updatedClientInfo.Name;
            client.LastName = updatedClientInfo.LastName;
            client.Email = updatedClientInfo.Email;
            client.Birthday = DateTime.Parse(updatedClientInfo.Birthday);
            client.Username = updatedClientInfo.Username;
            client.Password = updatedClientInfo.Password;

            await _libraryDB.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookLike(int clientId, int bookId)
        {
            var bookLike = await _libraryDB.ClientLikes
            .FirstOrDefaultAsync(bl => bl.IdClient == clientId && bl.IdBook == bookId);

            if (bookLike == null)
            {
                return false;
            }

            _libraryDB.ClientLikes.Remove(bookLike);
            await _libraryDB.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookReview(int clientId, int reviewId)
        {
            var review = await _libraryDB.Reviews
            .FirstOrDefaultAsync(r => r.IdClient == clientId && r.IdOfReview == reviewId);

            if (review == null)
            {
                return false;
            }

            _libraryDB.Reviews.Remove(review);
            await _libraryDB.SaveChangesAsync();

            return true;
        }
    }
}

