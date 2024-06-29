using GetFood.Infra.Gateways;
using GetFood.Infra.Services;
using GetFood.Models;

namespace GetFood.Application.Services
{
    public interface IPageInitialService
    {
        Task<CustomResult<PageResult<CategoryOutputModel>>> GetCategories(int size = 10, int index = 0);
    }

    public class PageInitialService : IPageInitialService
    {
        private readonly IRestaurantsFoodsGateway _restaurantsFoodsGateway;
        private readonly ICacheService _cacheService;

        public PageInitialService(IRestaurantsFoodsGateway restaurantsFoodsGateway, ICacheService cacheService)
        {
            _restaurantsFoodsGateway = restaurantsFoodsGateway;
            _cacheService = cacheService;
        }

        public async Task<CustomResult<PageResult<CategoryOutputModel>>> GetCategories(int size = 10, int index = 0)
        {
            var cacheKey = $"categories_{size}_{index}";

            var dataCache = await _cacheService.GetAsync<CustomResult<PageResult<CategoryOutputModel>>>(cacheKey);

            if (dataCache != null)
            {
                return dataCache;
            }

            var categories = await _restaurantsFoodsGateway.GetCategories(size, index);

            await _cacheService.SetAsync(cacheKey, categories);

            return categories;
        }
    }
}
