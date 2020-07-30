using JWTAuthentication_TokenBarer.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication_TokenBarer.Models
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        private List<Login> logins = new List<Login>()
        {
            new Login{LoginID =1, Email = "200414123@student.georianc.on.ca", Phone="51883811", UserName="mohammad", Password ="1234"}

        };


        public Login Authenticate(string userName, string password)
        {
            var login = logins.SingleOrDefault(x => x.Email == userName && x.Password == password);

            //return null if student not found
            if (login == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, login.LoginID.ToString()),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Version, "V3.1")
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                login.Token = tokenHandler.WriteToken(token);
                Console.WriteLine(login);
                return login;
            }
        }
    }
}