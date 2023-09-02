using BestbitePizza.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class GeneralController : ControllerBase
    {
        
        private readonly ILogger<GeneralController> _logger;
        

        public GeneralController(ILogger<GeneralController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("titles")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetTitles()
        {
            return Ok();
        }

        [HttpGet]
        [Route("socialmedia")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetSocialMedia()
        {
            return Ok();
        }

        [HttpGet]
        [Route("testimonials")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetTestimonials()
        {
            return Ok();
        }

        [HttpGet]
        [Route("clientqueries")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetClientQueries()
        {
            return Ok();
        }
    }
}