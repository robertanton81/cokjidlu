using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeIngredients, IngredientDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Ingredient.Id))
                .ForMember(dest => dest.Title, options => options.MapFrom(source => source.Ingredient.Title))
                .ForMember(dest => dest.IngredientCategory, o => o.MapFrom(src => src.Ingredient.IngredientCategory));
        }
    }
}
