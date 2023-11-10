
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using learnApi.Models;
using Microsoft.IdentityModel.Tokens;
namespace  learnApi.utils
{
    
    public class Utils
    {   
        private  readonly IConfiguration _configuration;

      
        

        public Utils(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));


            var key  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_is_a_good_key_fantastic_key_and_the_secret_and_password_is_a_bad_word_when_it"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, signingCredentials:cred,expires: DateTime.Now.AddDays(1));

            var jwt  = new JwtSecurityTokenHandler().WriteToken(token);

             return jwt;
        }   


    }


}