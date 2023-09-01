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
            return Ok(await _pizzaItemDataService.Get<MenuItem>(id));
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<MenuItemViewModel>>> GetAll()
        {
            // TODO: Update this to have MenuItemViewModel
            return Ok(await _pizzaItemDataService.GetAll<MenuItem>());
        }

        [HttpGet]
        [Route("ingredients")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            return Ok("ingredients");
        }

        [HttpGet]
        [Route("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok("Categories");
        }

        [HttpGet]
        [Route("vocab")]
        public async Task<ActionResult<IEnumerable<Vocab>>> GetVocabs()
        {
            return Ok("Vocabs");
        }

    }
}