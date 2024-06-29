using AutoMapper;
using FoodManager.Core.Mediator.Results;
using MediatR;
using RestaurantsFoods.Application.Models.OutputModels;
using RestaurantsFoods.Application.Queries.CategoryQuery.Queries;
using RestaurantsFoods.Domain.Repositories;

namespace RestaurantsFoods.Application.Queries.CategoryQuery.Handlers
{
    public class GetAllCCategoryHandler : IRequestHandler<GetAllCategoryQuery, CustomResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResult> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(request.Size, request.Index);

            var pageResult = new PageResult<CategoryOutputModel>
            {
                Items = categories.Items.Select(c => new CategoryOutputModel { Id = c.Id, ImageUrl = c.ImageUrl, Name = c.Name }),
                TotalResults = categories.TotalResults,
                PageIndex = categories.PageIndex,
                PageSize = categories.PageSize,
                TotalPages = categories.TotalPages,
                HasNextPage = categories.HasNextPage,
                HasPreviousPage = categories.HasPreviousPage,
            };


            return CustomResult.Success("Success", pageResult);
        }
    }
}
