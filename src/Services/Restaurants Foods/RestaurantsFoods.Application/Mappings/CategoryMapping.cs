using AutoMapper;
using FoodManager.Core.Mediator.Results;
using RestaurantsFoods.Application.Commands;
using RestaurantsFoods.Application.Models.OutputModels;
using RestaurantsFoods.Domain.Entities;

namespace RestaurantsFoods.Application.Mappings
{
    public class CategoryMapping : Profile
    {
        protected CategoryMapping()
        {
            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dst => dst.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dst => dst.ImageUrl, map => map.MapFrom(src => src.ImageUrl));

            CreateMap<Category, CategoryOutputModel>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dst => dst.ImageUrl, map => map.MapFrom(src => src.ImageUrl));

            CreateMap<PageResult<Category>, PageResult<CategoryOutputModel>>()
                .ForMember(dst => dst.PageIndex, map => map.MapFrom(src => src.PageIndex))
                .ForMember(dst => dst.TotalResults, map => map.MapFrom(src => src.TotalResults))
                .ForMember(dst => dst.PageSize, map => map.MapFrom(src => src.PageSize))
                .ForMember(dst => dst.TotalPages, map => map.MapFrom(src => src.TotalPages))
                .ForMember(dst => dst.HasNextPage, map => map.MapFrom(src => src.HasNextPage))
                .ForMember(dst => dst.HasPreviousPage, map => map.MapFrom(src => src.HasPreviousPage))
                .ForMember(dst => dst.Items, map => map.MapFrom(src => src.Items));
        }
    }
}

