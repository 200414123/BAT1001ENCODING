using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication_TokenBarer.Models;
using JWTAuthentication_TokenBarer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_TokenBarer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login model)
        {
            var student = _authenticateService.Authenticate(model.Email, model.Password);
            if (student == null)
            {
                return BadRequest(new { Message = "Error your email or password is incorrect" });
            }
            else
                return Ok(student);
        }

    }
}
