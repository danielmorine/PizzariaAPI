using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Commands.ClientCommands
{
    public class ClientCreateCommand : ClientCommand
    {
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ClientPhoneId { get; set; }
        public Guid ClientAddressId { get; set; }
    }
}
