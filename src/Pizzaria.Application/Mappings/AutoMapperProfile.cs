using AutoMapper;
using Pizzaria.Application.DTOs;
using Pizzaria.Domain.Account;
using Pizzaria.Domain.Entities;

namespace Pizzaria.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<Ingredient, IngredientDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<UserToken, UserTokenDTO>().ReverseMap();
    }
}
