using MediatR;
using Pizzaria.Application.Commands.ProductCommands;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ProductHandler;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, bool>
{
    private readonly IProductRepository _repository;

    public ProductCreateCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        Product product = new(Guid.NewGuid(), request.Name, DateTimeOffset.UtcNow);

        if (product is null)
            throw new ApplicationException("Error creating entity");

        await _repository.AddAsync(product);
        return true;
    }
}
