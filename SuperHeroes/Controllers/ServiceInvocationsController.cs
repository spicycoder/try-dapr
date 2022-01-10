using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceInvocationsController : ControllerBase
    {
        private readonly DaprClient _daprClient;

        public ServiceInvocationsController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpGet("[action]"), ActionName("contact")]
        public async Task<ActionResult<ContactInformation>> GetContact([FromQuery] string name)
        {
            var contact = await _daprClient.InvokeMethodAsync<string, ContactInformation>(HttpMethod.Get,  "contacts-provider", "Contacts/by-name", name);

            if (contact != null)
            {
                return Ok(contact);
            }

            return NotFound();
        }
    }
}
