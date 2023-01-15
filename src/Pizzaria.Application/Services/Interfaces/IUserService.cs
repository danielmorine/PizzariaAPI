using Pizzaria.Domain.Account;

namespace Pizzaria.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserToken> AuthenticateAsync(string email, string password);
    Task RegisterUserAsync(string email, string password);
    Task Logout();
}
