using Pizzaria.Infra.Data.Identity.Interfaces;
using Pizzaria.Infra.Data.Utils;

namespace Pizzaria.Infra.Data.Identity
{
    public sealed class JwtOptions : IJwtOptions
    {
        public string SecretKey { get; private set; }
        public string Issuer { get; private set; }
        public string Audience { get; private set; }

        public JwtOptions(string secretKey, string issuer, string audience)
        {
            SecretKey = StringUtils.GetValueFromFile(secretKey).Replace("\0", "");
            Issuer = StringUtils.GetValueFromFile(issuer).Replace("\0", "");
            Audience = StringUtils.GetValueFromFile(audience).Replace("\0", "");
        }
    }
}
