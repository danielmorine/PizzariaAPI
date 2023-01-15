using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Account;
using Pizzaria.Domain.Account.Interfaces;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Utils;

namespace Pizzaria.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthenticate _authenticate;

        public UserService(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        public async Task<UserToken> AuthenticateAsync(string email, string password)
        {
            var result = await _authenticate.AuthenticateAsync(email, password);

            if (result)
                return _authenticate.GenerateToken(new Login { Email = email, Password = password });

            throw new ApplicationException(MessageValidationEnum.UserOrPasswordInvalid.GetDescription());
        }

        public async Task Logout()
        {
            await _authenticate.Logout();
        }

        public async Task RegisterUserAsync(string email, string password)
        {
            await _authenticate.RegisterUserAsync(email, password);
        }
    }
}
