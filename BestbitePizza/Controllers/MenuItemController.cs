using BestbitePizza.DataServices.Contracts;
using BestbitePizza.Models;
using BestbitePizza.Models.DataModels;
using BestbitePizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("api/v1/menuitem/")]
    public class MenuItemController : ControllerBase
    {
        
        private readonly ILogger<MenuItemController> _logger;
        private readonly IMenuItemRepositoryAggregated _pizzaItemDataService;
        private readonly IMenuServiceAggregated _menuServiceAggregated;

        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemRepositoryAggregated pizzaItemDataService, IMenuServiceAggregated menuServiceAggregated)
        {
            _logger = logger;
            _pizzaItemDataService = pizzaItemDataService;
            _menuServiceAggregated = menuServiceAggregated;
        }

        [HttpGet]
        [Route("categorized")]
        public async Task<ActionResult<IEnumerable<CategorizedMenu>>> GetCategorizedMenuItems()
        {
            return Ok(await _menuServiceAggregated.GetCategorizedMenuItems());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> Get(int id)
        {
            return Ok(await _pizzaItemDataService.GetMenuItemById(id));
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
        {
            return Ok(await _pizzaItemDataService.GetAllMenuItems());
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