using BestbitePizza.DataServices.Dapper;
using BestbitePizza.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaItemController : ControllerBase
    {
        
        private readonly ILogger<PizzaItemController> _logger;
        private readonly IPizzaItemDataService _pizzaItemDataService;

        public PizzaItemController(ILogger<PizzaItemController> logger, IPizzaItemDataService pizzaItemDataService)
        {
            _logger = logger;
            _pizzaItemDataService = pizzaItemDataService;
        }

        [HttpGet(Name = "GetPizzaItem")]
        public IEnumerable<Item> Get()
        {
            return _pizzaItemDataService.GetPizzaItems();
        }
    }
}