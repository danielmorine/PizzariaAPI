using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Services.Interfaces;

public interface IUserService
{
    Task<IResponseResult<UserTokenDTO>> AuthenticateAsync(string email, string password);
    Task<ResponseResult> RegisterUserAsync(string email, string password);
    Task<ResponseResult> Logout();
}
