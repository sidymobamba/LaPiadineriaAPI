using AutoMapper;
using Piadineria2.Dto;
using Piadineria2.Entities;

namespace Piadineria2.Profiles
{
    public class PiadinaProfile : Profile
    {
        public PiadinaProfile()
        {
            CreateMap<PiadinaEntity, PiadinaWithIngredients>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients.Select(ingredient => ingredient.Name).ToList())).ReverseMap();

        }
    }
}
