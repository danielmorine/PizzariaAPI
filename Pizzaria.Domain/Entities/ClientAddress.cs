using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Utils;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities
{
    public sealed class ClientAddress : EntityBase
    {
        public string Address { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        public Client Client { get; set; }

        public ClientAddress(Guid id, DateTimeOffset date, string address, int number, string complement, string city, string zipCode)
        {
            ValidateIdDomain(id);
            ValidateClientAddressDomain(address, number, city, zipCode);

            Id = id;    
            CreatedDate= date;  
            Address = address;
            Number = number;
            Complement = complement;
            City = city;
            ZipCode = zipCode;
        }

        public void Update(string address, int number, string complement, string city, string zipCode)
        {
            ValidateClientAddressDomain(address, number, city, zipCode);

            Address = address;
            Number = number;
            Complement = complement;
            City = city;
            ZipCode = zipCode;
        }

        private static void ValidateClientAddressDomain(string address, int number, string city, string zipCode)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(address),
                MessageValidationEnum.ClientAddressAddressIsRequired.GetDescription());

            DomainExceptionValidation.When(address.Length > 200,
                MessageValidationEnum.ClientAddressAddressIsToLarge.GetDescription());

            DomainExceptionValidation.When(number > 0,
               MessageValidationEnum.ClientAddressNumberIsRequired.GetDescription());

            DomainExceptionValidation.When(number.ToString().Length > 10,
                MessageValidationEnum.ClientAddressNumberIsToLarge.GetDescription());

            DomainExceptionValidation.When(string.IsNullOrEmpty(city),
                MessageValidationEnum.ClientAddressCityIsRequired.GetDescription());

            DomainExceptionValidation.When(city.Length > 300,
                MessageValidationEnum.ClientAddressCityIsToLarge.GetDescription());

            DomainExceptionValidation.When(string.IsNullOrEmpty(zipCode),
                MessageValidationEnum.ClientAddressZipCodeIsRequired.GetDescription());

            DomainExceptionValidation.When(zipCode.Length > 10,
                MessageValidationEnum.ClientAddressZipCodeIsToLarge.GetDescription());
        }
    }
}
