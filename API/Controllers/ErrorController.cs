using Microsoft.AspNetCore.Mvc;

namespace PhobosReact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ApiController
    {
        [Route("Error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}