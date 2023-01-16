using AutoMapper;
using Pizzaria.Application.Commands.IngredientCommands;
using Pizzaria.Application.Commands.ProductCommands;
using Pizzaria.Application.DTOs;

namespace Pizzaria.Application.Mappings;

public class AutoMapperCommandProfile : Profile
{
    public AutoMapperCommandProfile() 
    {
        CreateMap<IngredientDTO, IngredientCreateCommand>();
        CreateMap<IngredientDTO, IngredientUpdateCommand>();
        CreateMap<Guid, IngredientRemoveCommand>();

        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
        CreateMap<Guid, ProductRemoveCommand>();
    }
}
