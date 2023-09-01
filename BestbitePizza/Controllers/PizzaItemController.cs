using BestbitePizza.DataServices.Contracts;
using BestbitePizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaItemController : ControllerBase
    {
        
        private readonly ILogger<PizzaItemController> _logger;
        private readonly IMenuItemDataService _pizzaItemDataService;

        public PizzaItemController(ILogger<PizzaItemController> logger, IMenuItemDataService pizzaItemDataService)
        {
            _logger = logger;
            _pizzaItemDataService = pizzaItemDataService;
        }

        [HttpGet(Name = "GetPizzaItem")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> Get()
        {
            return Ok(await _pizzaItemDataService.GetPizzaItems());
        }
    }
}