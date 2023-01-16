using MediatR;
using Pizzaria.Application.Commands.ProductCommands;
using Pizzaria.Domain.Interfaces;

namespace Pizzaria.Application.Handlers.ProductHandler;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, bool>
{
    private readonly IProductRepository _repository;

    public ProductUpdateCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return false;
        }            

        product.Update(request.Name);

        await _repository.UpdateAsync(product);
        return true;
    }
}
