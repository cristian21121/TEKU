namespace Domain.Models
{
    public class AuthenticationRequest
    {
        public required String Username { get; set; }

        public required String Password { get; set; }
    }
}