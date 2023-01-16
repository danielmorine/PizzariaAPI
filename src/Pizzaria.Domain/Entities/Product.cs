using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities;

public sealed class Product : EntityBase
{
    public string Name { get; private set; }

    public ICollection<ProductIngredient>? ProductIngredients { get; set; }

    public Product(Guid id, string name, DateTimeOffset createdDate)
    {
        ValidateIdDomain(id);
        ValidatenNameDomain(name);
        Id = id;
        Name = name;
        CreatedDate = createdDate;
    }

    public void Update(string name)
    {
        ValidatenNameDomain(name);
        Name = name;
    }

    private static void ValidatenNameDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            MessageValidation.ProductNameIsRequired);

        DomainExceptionValidation.When(name.Length > 50,
            MessageValidation.ProductNameIsToLarge);
    }            
}
