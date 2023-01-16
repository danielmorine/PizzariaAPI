using AutoMapper;
using MediatR;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Queries.IngredientQueries;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Messges;

namespace Pizzaria.Application.Services;

public class IngredientService : IIngredientService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public IngredientService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ResponseResult> AddAsync(IngredientDTO dto)
    {
        var responseResult = new ResponseResult();

        try
        {
            var ingredient = _mapper.Map<IngredientCreateCommand>(dto);
            await _mediator.Send(ingredient);

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
            var ingredient = new IngredientRemoveCommand { Id = id };
            var result = await _mediator.Send(ingredient);

            if (result is false)
                responseResult.MessageError = new[] { MessageValidation.IngredientDeleteFailed };
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

    public async Task<IResponseResult<IEnumerable<IngredientDTO>>> GetAllAsync()
    {
        var responseResult = new ResponseResult<IEnumerable<IngredientDTO>>();

        try
        {
            var result = await _mediator.Send(new GetAllIngredientQuery());
            var ingredientList = _mapper.Map<IEnumerable<IngredientDTO>>(result);

            responseResult.Success = true;
            responseResult.Payload = ingredientList;
        }
        catch (Exception ex)
        {
            responseResult.Success = false;
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }

    public async Task<IResponseResult<IngredientDTO>> GetByIdAsync(Guid id)
    {
        var responseResult = new ResponseResult<IngredientDTO>();
        try
        {
            var result = await _mediator.Send(new GetIngredientByIdQuery(id));
            var ingredientDTO = _mapper.Map<IngredientDTO>(result);

            if (ingredientDTO is null)
                responseResult.MessageError = new string[] { MessageValidation.IngredientNotFound }; 
            else
            {
                responseResult.Success = true;
                responseResult.Payload = ingredientDTO;
            }
        }   
        catch (Exception ex)
        {
            responseResult.Success = false; 
            responseResult.MessageError = new[] { ex.Message };
        }

        return responseResult;
    }

    public async Task<ResponseResult> UpdateAsync(IngredientDTO dto)
    {
        var responseResult = new ResponseResult();
        try
        {
            var ingredientUpdate = _mapper.Map<IngredientUpdateCommand>(dto);
            var result = await _mediator.Send(ingredientUpdate);

            if (result is false)
            {
                responseResult.Success = false;
                responseResult.MessageError = new[] { MessageValidation.IngredientNotFound };
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
