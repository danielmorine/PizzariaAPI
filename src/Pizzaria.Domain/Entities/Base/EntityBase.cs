using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Validation;

namespace Pizzaria.Domain.Entities.Base;

public class EntityBase
{
    public Guid Id { get; protected set; }
    public DateTimeOffset CreatedDate { get; protected set; }

    public static void ValidateIdDomain(Guid id)
    {
        DomainExceptionValidation.When(id == Guid.Empty,
            MessageValidation.InvalidId);
    }
}
