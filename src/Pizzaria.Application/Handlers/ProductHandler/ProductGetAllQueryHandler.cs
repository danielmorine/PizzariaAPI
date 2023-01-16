using MediatR;
using Pizzaria.Application.Queries.ProductQueries;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ProductHandler;

public class ProductGetAllQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _repository;

    public ProductGetAllQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Product?>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
