using MediatR;
using Pizzaria.Application.Commands.ProductCommands;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ProductHandler;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, bool>
{
    private readonly IProductRepository _repository;

    public ProductRemoveCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return false;
        }

        await _repository.DeleteAsync(product);

        return true;
    }
}
