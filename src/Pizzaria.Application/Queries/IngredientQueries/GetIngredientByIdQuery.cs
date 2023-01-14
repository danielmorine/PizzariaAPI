using MediatR;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Queries.IngredientQueries
{
    public class GetIngredientByIdQuery : IRequest<Ingredient>
    {
        public Guid Id { get; private set; }

        public GetIngredientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
