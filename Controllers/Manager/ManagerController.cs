using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system_API.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManager _manager;
        
        public ManagerController(IManager manager)
        {
            _manager = manager;
        }

        [HttpGet("get-manager-by-id/{id:int}")]
        public async Task<IActionResult> GetManagerById(int id)
        {
            var manager = await _manager.GetManagerInfo(id);

            if (manager == null) {
                return NotFound();
            }
            
            return Ok(manager);
        }

    }
}
