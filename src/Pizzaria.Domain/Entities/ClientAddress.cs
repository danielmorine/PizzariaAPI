using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Utils;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities;

public sealed class ClientAddress : EntityBase
{
    public string Address { get; private set; }
    public int Number { get; private set; }
    public string Complement { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }

    public Client Client { get; set; }

    public ClientAddress(Guid id, DateTimeOffset createdDate, string address, int number, string complement, string city, string zipCode)
    {
        ValidateIdDomain(id);
        ValidateClientAddressDomain(address, number, city, zipCode);

        Id = id;    
        CreatedDate= createdDate;  
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
            MessageValidation.ClientAddressAddressIsRequired);

        DomainExceptionValidation.When(address.Length > 200,
            MessageValidation.ClientAddressAddressIsToLarge);

        DomainExceptionValidation.When(number > 0,
           MessageValidation.ClientAddressNumberIsRequired);

        DomainExceptionValidation.When(number.ToString().Length > 10,
            MessageValidation.ClientAddressNumberIsToLarge);

        DomainExceptionValidation.When(string.IsNullOrEmpty(city),
            MessageValidation.ClientAddressCityIsRequired);

        DomainExceptionValidation.When(city.Length > 300,
            MessageValidation.ClientAddressCityIsToLarge);

        DomainExceptionValidation.When(string.IsNullOrEmpty(zipCode),
            MessageValidation.ClientAddressZipCodeIsRequired);

        DomainExceptionValidation.When(zipCode.Length > 10,
            MessageValidation.ClientAddressZipCodeIsToLarge);
    }
}
