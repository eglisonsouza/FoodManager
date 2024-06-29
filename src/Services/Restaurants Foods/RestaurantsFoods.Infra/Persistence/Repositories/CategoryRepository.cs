using FoodManager.Core.Data;
using FoodManager.Core.Mediator.Results;
using Microsoft.EntityFrameworkCore;
using RestaurantsFoods.Domain.Entities;
using RestaurantsFoods.Domain.Repositories;

namespace RestaurantsFoods.Infra.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RestaurantsFoodsContext _context;

        public CategoryRepository(RestaurantsFoodsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(Category category)
        {
            await _context.AddAsync(category);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<PageResult<Category>> GetAllAsync(int size, int index)
        {
            var categories = await _context.Categories.AsNoTracking().Skip(index).Take(size).ToListAsync();
            var count = await _context.Categories.AsNoTracking().CountAsync();

            return new PageResult<Category>()
            {
                Items = categories,
                TotalResults = count,
                PageIndex = index,
                PageSize = size,
                TotalPages = count / size,
                HasNextPage = count / size > index,
                HasPreviousPage = index > 1,
            };
        }
    }
}
