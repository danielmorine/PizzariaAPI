using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities;

public sealed class Ingredient : EntityBase
{
    public string Name { get; private set; }

    public ICollection<ProductIngredient>? ProductIngredients { get; set; }

    public Ingredient(Guid id, string name, DateTimeOffset createdDate)
    {
        ValidatenNameDomain(name);
        ValidateIdDomain(id);

        Id = id;            
        CreatedDate = createdDate;            
        Name = name;
    }

    public void Update(string name)
    {
        ValidatenNameDomain(name);
        Name = name;
    } 

    private static void ValidatenNameDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            MessageValidation.IngredientNameIsRequired);

        DomainExceptionValidation.When(name.Length > 50,
            MessageValidation.IngredientNameIsToLarge);
    }        
}
