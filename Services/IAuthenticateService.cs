using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication_TokenBarer.Models;

namespace JWTAuthentication_TokenBarer.Services
{
    public interface IAuthenticateService
    {
        Login Authenticate(String Email, String Password);
    }
}
