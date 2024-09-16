using Microsoft.AspNetCore.Mvc;

namespace FlintSoft.CRM.Api.Controllers;

[ApiController]
[Route("bp")]
public class BusinesspartnersController : ApiController
{
    public IActionResult ListBusinesspartners()
    {
        return Ok(Array.Empty<string>());
    }
}
