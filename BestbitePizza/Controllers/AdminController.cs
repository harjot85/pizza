using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("api/v1/admin/")]
    public class AdminController : ControllerBase
    {

        private readonly ILogger<MenuItemController> _logger;

        public AdminController(ILogger<MenuItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [Route("report")]
        public IActionResult GetReport()
        {
            return Ok("Generating report...");
        }

        [HttpPost]
        [Route("ingredient/add")]
        public async Task<IActionResult> AddIngredient()
        {
            return Ok();
        }

        [HttpPost]
        [Route("menuitem/add")]
        public async Task<IActionResult> AddMenuItem()
        {
            return Ok();
        }

        [HttpPost]
        [Route("category/add")]
        public async Task<IActionResult> AddCategory()
        {
            return Ok();
        }
    }
}