using Pizzaria.Domain.Entities.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Utils;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }

        public ICollection<ProductIngredient>? ProductIngredients { get; set; }

        public Product(Guid id, string name, DateTimeOffset date)
        {
            ValidateIdDomain(id);
            ValidatenNameDomain(name);
            Id = id;
            Name = name;
            CreatedDate = date;
        }

        public void Update(string name)
        {
            ValidatenNameDomain(name);
            Name = name;
        }

        private static void ValidatenNameDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                MessageValidationEnum.ProductNameIsRequired.GetDescription());

            DomainExceptionValidation.When(name.Length > 50,
                MessageValidationEnum.ProductNameIsToLarge.GetDescription());
        }            
    }
}
