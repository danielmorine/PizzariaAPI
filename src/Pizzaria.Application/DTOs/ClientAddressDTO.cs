namespace Pizzaria.Application.DTOs
{
    public class ClientAddressDTO
    {
        public Guid? Id { get; set; }
        public string Address { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
    }
}
