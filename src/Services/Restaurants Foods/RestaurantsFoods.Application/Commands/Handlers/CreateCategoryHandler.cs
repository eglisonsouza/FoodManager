using AutoMapper;
using FoodManager.Core.Mediator.Results;
using MediatR;
using RestaurantsFoods.Domain.Entities;
using RestaurantsFoods.Domain.Repositories;

namespace RestaurantsFoods.Application.Commands.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CustomResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddAsync(_mapper.Map<Category>(request)!);

            if (await _categoryRepository.UnitOfWork.CommitAsync())
            {
                return CustomResult.Success("Category created successfully.");
            }

            return CustomResult.Fail("Error creating category.");
        }
    }
}
