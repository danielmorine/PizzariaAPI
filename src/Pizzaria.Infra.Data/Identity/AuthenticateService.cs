using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Pizzaria.Domain.Account;
using Pizzaria.Domain.Account.Interfaces;
using Pizzaria.Domain.Messges;
using Pizzaria.Infra.Data.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pizzaria.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtOptions _jwtOptions;        

    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtOptions jwtOptions)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtOptions = jwtOptions;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public UserToken GenerateToken(Login login)
    {
        var secretKey = StringUtils.GetValueFromFile(_jwtOptions.SecretKey).Replace("\0", "");
        var issuer = StringUtils.GetValueFromFile(_jwtOptions.Issuer).Replace("\0", "");
        var audience = StringUtils.GetValueFromFile(_jwtOptions.Audience).Replace("\0", "");
        var expiration = DateTime.UtcNow.AddMinutes(30);

        var claims = CreateClaims(login);
        var credentials = CreateSigningCredentials(secretKey);            

        var token = CreateJwtSecurityToken(
            issuer,
            audience,
            claims,
            expiration,
            credentials
            );

        return new UserToken
        {
            Expiration = expiration,
            Token = token
        };
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<bool> RegisterUserAsync(string email, string password)
    {
        try
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new ApplicationException(MessageValidation.UserRegisterFailure);

            return result.Succeeded;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.ToString());
        }           
    }

    private static Claim[] CreateClaims(Login login) => new[]
    {
        new Claim("email", login.Email),
        new Claim("valueBlaBlaBla", "blablabla"),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    private static SigningCredentials CreateSigningCredentials(string secretKey)
    {
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        return new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
    }

    private static string CreateJwtSecurityToken(string issuer, string audience, Claim[] claims, DateTime expiration, SigningCredentials credentials)
    {
        var token = new JwtSecurityToken(
           issuer: issuer,
           audience: audience,
           claims: claims,
           expires: expiration,
           signingCredentials: credentials
           );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
