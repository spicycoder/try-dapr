using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Common;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly DaprClient _daprClient;

        public StatesController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpGet("[action]"), ActionName("read-hero")]
        public async Task<ActionResult<Hero>> GetHeroe([FromQuery] string name)
        {
            var hero = await _daprClient.GetStateAsync<Hero>(Constants.StateStoreName, name);
            return Ok(hero);
        }

        [HttpPost("[action]"), ActionName("save-hero")]
        public async Task<IActionResult> SaveHero([FromBody] Hero hero)
        {
            await _daprClient.SaveStateAsync(Constants.StateStoreName, hero.Name, hero);
            return Ok();
        }
    }
}
