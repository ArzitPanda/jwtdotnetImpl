
using learnApi.Models;
using learnApi.utils;
using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();


       private readonly Utils _utils;

    public AuthController(IConfiguration configuration)
    {
        _utils = new Utils(configuration);
    }



        [HttpPost("signup")]
        public ActionResult<User> Register(Dto.UserDto request)
        {
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.PasswordHash = PasswordHash;


            return Ok(user);

        }


          [HttpPost("login")]
        public ActionResult<User> Login(Dto.UserDto request)
        {

                if(request.Username != user.Username)
                {
                    return BadRequest("Username mismatch");
                }


            bool check = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

                if(check == true)
                {
                    string token = _utils.CreateToken(user);
                    return Ok(token);
                }

            return Unauthorized();
        }





    }
}