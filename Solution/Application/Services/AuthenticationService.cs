using Application.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Boolean Validate(AuthenticationRequest authenticationRequest)
        {
            Boolean result = false;

            if (authenticationRequest.Username == "root" &&  authenticationRequest.Password == "root")
            {
                result = true;
            }

            return result;
        }
    }
}