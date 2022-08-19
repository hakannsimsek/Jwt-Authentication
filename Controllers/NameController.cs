using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Auth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] 
    public class NameController : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public NameController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // GET: NameController
        public string Index()
        {
            return "You are succesfully authorized";
        }

        [AllowAnonymous]
        // GET: NameController/Create
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody]UserCred userCred)
        {
            var token = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
