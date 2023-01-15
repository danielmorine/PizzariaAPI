using AutoMapper;
using MediatR;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Queries.IngredientQueries;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IngredientService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddAsync(IngredientDTO dto)
        {
            var ingredient = _mapper.Map<IngredientCreateCommand>(dto);
            await _mediator.Send(ingredient);
        }

        public async Task DeleteAsync(Guid id)
        {
            var ingredientDTO = await GetByIdAsync(id);

            if (ingredientDTO == null)
                throw new ApplicationException("Ingrediente não encontrado");

            var ingredient = _mapper.Map<IngredientRemoveCommand>(ingredientDTO);
            await _mediator.Send(ingredient);
        }

        public async Task<IEnumerable<IngredientDTO>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllIngredientQuery());
            return _mapper.Map<IEnumerable<IngredientDTO>>(result);
        }

        public async Task<IngredientDTO> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetIngredientByIdQuery(id));
            return _mapper.Map<IngredientDTO>(result);
        }

        public async Task UpdateAsync(IngredientDTO dto)
        {
            var ingredientUpdate = _mapper.Map<IngredientUpdateCommand>(dto);
            await _mediator.Send(ingredientUpdate);            
        }
    }
}
