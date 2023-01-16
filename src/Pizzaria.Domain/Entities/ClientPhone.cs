using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Utils;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities;

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
            MessageValidation.ClientPhoneRegionIsRequired);

        DomainExceptionValidation.When(string.IsNullOrEmpty(number),
            MessageValidation.ClientPhoneNumberIsRequired);

        DomainExceptionValidation.When(number.Length > 10,
            MessageValidation.ClientPhoneNumberIsToLargeRequired);

        DomainExceptionValidation.When(regionNumber.Length > 3,
            MessageValidation.ClientPhoneRegionIsToLargeRequired);
    }
}
