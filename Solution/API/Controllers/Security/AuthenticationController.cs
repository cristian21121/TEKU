using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Security
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Post(AuthenticationRequest authenticationRequest)
        {
            if (authenticationService.Validate(authenticationRequest))
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }
    }
}