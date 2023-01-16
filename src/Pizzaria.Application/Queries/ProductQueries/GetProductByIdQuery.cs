using MediatR;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Queries.ProductQueries;

public class GetProductByIdQuery : IRequest<Product>
{
    public Guid Id { get; private set; }

	public GetProductByIdQuery(Guid id)
	{
		Id = id;
	}   
}
