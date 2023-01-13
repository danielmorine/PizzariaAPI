using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Utils;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities
{
    public sealed class ClientPhone : EntityBase
    {
        public string RegionNumber { get; private set; }
        public string Number { get; private set; }

        public Client Client { get; set; }

        public ClientPhone(Guid id, DateTimeOffset createdDate, string regionNumber, string number)
        {
            ValidateIdDomain(id);
            ValidatePhoneDomain(regionNumber, number);

            Id = id;
            CreatedDate = createdDate;
            RegionNumber = regionNumber;
            Number = number;
        }

        public void Update(string regionNumber, string number)
        {
            ValidatePhoneDomain(regionNumber, number);

            RegionNumber = regionNumber; 
            Number = number;
        }

        private static void ValidatePhoneDomain(string regionNumber, string number)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(regionNumber),
                MessageValidationEnum.ClientPhoneRegionIsRequired.GetDescription());

            DomainExceptionValidation.When(string.IsNullOrEmpty(number),
                MessageValidationEnum.ClientPhoneNumberIsRequired.GetDescription());

            DomainExceptionValidation.When(number.Length > 10,
                MessageValidationEnum.ClientPhoneNumberIsToLargeRequired.GetDescription());

            DomainExceptionValidation.When(regionNumber.Length > 3,
                MessageValidationEnum.ClientPhoneRegionIsToLargeRequired.GetDescription());
        }
    }
}
