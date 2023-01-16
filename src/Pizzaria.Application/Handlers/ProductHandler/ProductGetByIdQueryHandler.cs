using MediatR;
using Pizzaria.Application.Queries.ProductQueries;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ProductHandler;

public class ProductGetByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _repository;

    public ProductGetByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
