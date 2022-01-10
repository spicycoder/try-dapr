using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Common;

namespace SuperHeroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly DaprClient _daprClient;

        public SecretsController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpGet("[action]"), ActionName("read-identity")]
        public async Task<ActionResult<string>> GetIdentity([FromQuery] string name)
        {
            var identity = await _daprClient.GetSecretAsync(Constants.SecretStore, name);
            return Ok(identity);
        }
    }
}
