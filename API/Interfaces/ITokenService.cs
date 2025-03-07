using API.Entities;

namespace API;

/// <summary>
/// This interface is used to define the methods that will be used to create a token.
/// </summary>
public interface ITokenService
{
    string CreateToken(AppUser appUser);

}
