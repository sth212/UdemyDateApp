using UdemyDateApp.Entities;

namespace UdemyDateApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
