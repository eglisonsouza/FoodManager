using FoodManager.Core.Data;
using FoodManager.Core.Mediator.Results;
using RestaurantsFoods.Domain.Entities;

namespace RestaurantsFoods.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task AddAsync(Category category);
        Task<PageResult<Category>> GetAllAsync(int size, int index);
    }
}
