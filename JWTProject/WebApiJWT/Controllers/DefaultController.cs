using WebApiJWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Token()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult TokenForRole()
        {
            return Ok(new CreateToken().TokenCreateForRole());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Auth()
        {
            return Ok("Welcome");
        }

        [Authorize(Roles = "Admin, Visitor")]
        [HttpGet("[action]")]
        public IActionResult AuthForRole()
        {
            return Ok("The entry was successful.");
        }
    }
}
