using Domain.Models;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Boolean Validate(AuthenticationRequest authenticationRequest);
    }
}