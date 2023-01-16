using MediatR;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Queries.ProductQueries;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{ }
