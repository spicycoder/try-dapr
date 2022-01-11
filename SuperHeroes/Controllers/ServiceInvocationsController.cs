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
            var httpClient = DaprClient.CreateInvokeHttpClient("contacts-provider");
            var contact = await httpClient.GetFromJsonAsync<ContactInformation>($"/Contacts/by-name?name={name}");

            if (contact != null)
            {
                return Ok(contact);
            }

            return NotFound();
        }
    }
}
