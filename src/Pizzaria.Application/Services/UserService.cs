using AutoMapper;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Account;
using Pizzaria.Domain.Account.Interfaces;
using Pizzaria.Domain.Messges;

namespace Pizzaria.Application.Services;

public class UserService : IUserService
{
    private readonly IAuthenticate _authenticate;
    private readonly IMapper _mapper;

    public UserService(IAuthenticate authenticate, IMapper mapper)
    {
        _authenticate = authenticate;
        _mapper = mapper;
    }

    public async Task<IResponseResult<UserTokenDTO>> AuthenticateAsync(string email, string password)
    {
        var responseResult = new ResponseResult<UserTokenDTO>();
        try
        {           
            var result = await _authenticate.AuthenticateAsync(email, password);

            if (result)
            {
                var userToken = _authenticate.GenerateToken(new Login { Email = email, Password = password });

                if (userToken is not null)
                {
                    responseResult.Success = true;
                    responseResult.Payload = _mapper.Map<UserTokenDTO>(userToken);
                    return responseResult;
                }
            }

            responseResult.Success = false;
            responseResult.MessageError = new[] { MessageValidation.UserOrPasswordInvalid };
            return responseResult;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
            return responseResult;
        }        
    }

    public async Task<ResponseResult> Logout()
    {
        var responseResult = new ResponseResult();
        try
        {            
            await _authenticate.Logout();
            responseResult.Success = true;            
        }
        catch (Exception ex)
        {

            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };            
        }

        return responseResult;
    }

    public async Task<ResponseResult> RegisterUserAsync(string email, string password)
    {
        var responseResult = new ResponseResult();
        try
        {
            await _authenticate.RegisterUserAsync(email, password);
            responseResult.Success = true;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;        
    }
}
