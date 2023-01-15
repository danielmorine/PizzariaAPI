namespace Pizzaria.Application.DTOs
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
