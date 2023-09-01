using BestbitePizza.DataServices.Contracts;
using BestbitePizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("api/v1/menuitem/")]
    public class MenuItemController : ControllerBase
    {
        
        private readonly ILogger<MenuItemController> _logger;
        private readonly IMenuItemDataService _pizzaItemDataService;

        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemDataService pizzaItemDataService)
        {
            _logger = logger;
            _pizzaItemDataService = pizzaItemDataService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> Get(int id)
        {
            return Ok(await _pizzaItemDataService.GetPizzaItem(id));
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
        {
            return Ok(await _pizzaItemDataService.GetPizzaItems());
        }
    }
}