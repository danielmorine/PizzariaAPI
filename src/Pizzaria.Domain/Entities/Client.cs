using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities;

public sealed class Client : EntityBase
{
    public string Name { get; private set; }

    public Client(Guid id, string name, DateTimeOffset createdDate) 
    {
        ValidateIdDomain(id);   
        ValidatenNameDomain(name);

        Name = name;
        Id = id;
        CreatedDate = createdDate;          
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
            MessageValidation.ClientNameIsRequired);

        DomainExceptionValidation.When(name.Length > 50,
            MessageValidation.ClientNameIsToLarge);
    }
}
