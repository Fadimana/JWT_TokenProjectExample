using Business.Layer.Interface;
using DataAccess.Layer.Entity;
using JWT_TokenExample.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWT_TokenExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserBusiness _userBusiness;

        public UserController(IConfiguration config, IUserBusiness userBusiness)
        {
            _config = config;
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken(string token) {
            List<Claim> a =TokenValidation.tokenValidation(token, _config);
            var c = a[0].Value;

            var b = await _userBusiness.GetUser1(c);
            return Ok(b);   
            
        }
        [HttpPost]
        public async Task<IActionResult> Post(User1 user)
        {
            var b = await _userBusiness.CreateUser(user);
            if (b == null)
            {
                return BadRequest("hatalı işlem");

            }
            Token token = TokenHAndler.CreateToken(_config, user.Id, user.E_Mail);
            return Ok(token);
        }
    }
}
