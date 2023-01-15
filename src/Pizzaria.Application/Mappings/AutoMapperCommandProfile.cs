using AutoMapper;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Mappings;

public class AutoMapperCommandProfile : Profile
{
    public AutoMapperCommandProfile() 
    {
        CreateMap<IngredientDTO, IngredientCreateCommand>();
        CreateMap<IngredientDTO, IngredientUpdateCommand>();
    }
}
