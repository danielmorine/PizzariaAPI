using AutoMapper;
using MediatR;
using Pizzaria.Application.Commands.ProductCommands;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Queries.ProductQueries;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Messges;

namespace Pizzaria.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ResponseResult> AddAsync(ProductDTO dto)
    {
        var responseResult = new ResponseResult();

        try
        {
            var product = _mapper.Map<ProductCreateCommand>(dto);
            await _mediator.Send(product);

            responseResult.Success = true;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }

    public async Task<ResponseResult> DeleteAsync(Guid id)
    {
        var responseResult = new ResponseResult();

        try
        {
            var product = new ProductRemoveCommand(id);
            var result = await _mediator.Send(product);

            if (result is false)
                responseResult.MessageError = new[] { MessageValidation.ProductDeleteFailed };
            else
                responseResult.Success = true;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }

    public async Task<IResponseResult<IEnumerable<ProductDTO>>> GetAllAsync()
    {
        var responseResult = new ResponseResult<IEnumerable<ProductDTO>>();

        try
        {
            var result = await _mediator.Send(new GetAllProductQuery());
            var productList = _mapper.Map<IEnumerable<ProductDTO>>(result);

            responseResult.Success = true;
            responseResult.Payload = productList;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }

    public async Task<IResponseResult<ProductDTO>> GetByIdAsync(Guid id)
    {
        var responseResult = new ResponseResult<ProductDTO>();
        try
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            var productDTO = _mapper.Map<ProductDTO>(result);

            if (productDTO is null)
                responseResult.MessageError = new string[] { MessageValidation.ProductNotFound }; 
            else
            {
                responseResult.Success = true;
                responseResult.Payload = productDTO;
            }
        }   
        catch (Exception ex)
        {
            responseResult.Success = false; 
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }

    public async Task<ResponseResult> UpdateAsync(ProductDTO dto)
    {
        var responseResult = new ResponseResult();
        try
        {
            var productUpdate = _mapper.Map<ProductUpdateCommand>(dto);
            var result = await _mediator.Send(productUpdate);

            if (result is false)
            {
                responseResult.Success = false;
                responseResult.MessageError = new[] { MessageValidation.ProductNotFound };
            }
            responseResult.Success = true;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }
}
