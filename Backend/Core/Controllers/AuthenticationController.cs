using BusinessLogic.Validators;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Protocol.Request;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(StudentRegistryContext context, IConfiguration configuration) : ControllerBase
    {
        private readonly StudentRegistryContext _context = context;
        private readonly IConfiguration _configuration = configuration;

        [Authorize]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(CreatedResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status401Unauthorized)]
        public ActionResult Login([FromBody] AuthenticationRequest auth)
        {
            return Ok();
        }
    }
}
