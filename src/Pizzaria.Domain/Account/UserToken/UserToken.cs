namespace Pizzaria.Domain.Account
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
