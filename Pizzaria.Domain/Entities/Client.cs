using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Utils;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities
{
    public sealed class Client : EntityBase
    {
        public string Name { get; private set; }

        public Client(Guid id, string name, DateTimeOffset date) 
        {
            ValidateIdDomain(id);   
            ValidatenNameDomain(name);

            Name = name;
            Id = id;
            CreatedDate = date;          
        }
        public void Update(string name)
        {
            ValidatenNameDomain(name);
            Name = name;
        }

        public Guid ClientPhoneId { get; set; }
        public ClientPhone ClientPhone { get; set; }

        public Guid ClientAddressId { get; set; }
        public ClientAddress ClientAddress { get; set; }


        private static void ValidatenNameDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                MessageValidationEnum.ClientNameIsRequired.GetDescription());

            DomainExceptionValidation.When(name.Length > 50,
                MessageValidationEnum.ClientNameIsToLarge.GetDescription());
        }
    }
}
