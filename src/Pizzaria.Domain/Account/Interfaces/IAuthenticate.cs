namespace Pizzaria.Domain.Account.Interfaces;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> RegisterUserAsync(string email, string password);
    Task Logout();
    UserToken GenerateToken(Login login);
}
