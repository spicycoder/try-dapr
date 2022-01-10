using Bogus;
using ContactsProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsProvider.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet("[action]"), ActionName("by-name")]
        public ActionResult<ContactInformation> GetContact(string name)
        {
            var contact = new Faker<ContactInformation>()
                .RuleFor(x => x.Name, _ => name)
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
                .Generate();

            return Ok(contact);
        }
    }
}
