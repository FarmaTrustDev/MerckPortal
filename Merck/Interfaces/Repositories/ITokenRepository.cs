using Merck.DTOS.Auth;
using Merck.Models;

namespace Merck.Interfaces.Repositories
{
    public interface ITokenRepository
    {
        string BuildToken(string key, string issuer, string audience, User user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
