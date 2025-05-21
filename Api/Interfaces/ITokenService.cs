using Api.Models;

namespace Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        public string? DecodeToken(string token);
    }
}
