using Library_management_system_API.Dto.Manager;
using Library_management_system_API.Models;
using Library_management_system_API.Services.Manager;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clients;

        public ClientsController(IClientService clients)
        {
            _clients = clients;
        }

        [HttpGet("get-all-clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clients.GetAllClients();

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpDelete("delete-client/{clientId:int}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            var result = await _clients.DeleteClient(clientId);

            if (!result)
            {
                return NotFound(new { message = $"Client with ID {clientId} not found." });
            }

            return Ok(new { message = $"Client with ID {clientId} deleted successfully." });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchClients([FromQuery] string query)
        {
            var clients = await _clients.SearchClientAsync(query);

            if (!clients.Any())
            {
                return NotFound("No clients found matching the search criteria.");
            }

            return Ok(clients);
        }

        [HttpGet("get-client-info/{clientId:int}")]
        public async Task<IActionResult> GetClientInfo(int clientId)
        {
            var clientInfo = await _clients.GetClientInfo(clientId);

            if (clientInfo == null)
            {
                return NotFound("No clients found matching this id.");
            }

            return Ok(clientInfo);
        }

        [HttpGet("{clientId}/purchased-books")]
        public async Task<IActionResult> GetPurchasedBooks(int clientId)
        {
            var purchasedBooks = await _clients.GetPurchasedBooks(clientId);

            return Ok(purchasedBooks);
        }

        [HttpGet("{clientId}/liked-books")]
        public async Task<IActionResult> GetLikedBooks(int clientId)
        {
            var likedBooks = await _clients.GetLikedBooks(clientId);

            return Ok(likedBooks);
        }

        [HttpGet("{clientId}/reviews")]
        public async Task<IActionResult> GetClientReviews(int clientId)
        {
            var reviews = await _clients.GetClientReviews(clientId);

            return Ok(reviews);
        }


        [HttpPut("edit-client/{clientId}")]
        public async Task<IActionResult> EditClientInfo(int clientId, [FromBody] ClientInfoDto updatedClientInfo)
        {
            var isUpdated = await _clients.EditClientInfo(clientId, updatedClientInfo);

            if (!isUpdated)
            {
                return NotFound("Client not found or no changes were made.");
            }

            return Ok("Client information updated successfully.");
        }


        [HttpDelete("clients/{clientId}/liked-books/{bookId}")]
        public async Task<IActionResult> DeleteBookLike(int clientId, int bookId)
        {
            var isDeleted = await _clients.DeleteBookLike(clientId, bookId);

            if (!isDeleted)
            {
                return NotFound("Book like not found.");
            }

            return Ok("Book like deleted successfully.");
        }

        [HttpDelete("clients/{clientId}/reviews/{reviewId}")]
        public async Task<IActionResult> DeleteBookReview(int clientId, int reviewId)
        {
            var isDeleted = await _clients.DeleteBookReview(clientId, reviewId);

            if (!isDeleted)
            {
                return NotFound("Review not found.");
            }

            return Ok("Review deleted successfully.");
        }

    }
}
