using GetFood.Models;
using System.Text.Json;

namespace GetFood.Infra.Gateways
{
    public interface IRestaurantsFoodsGateway
    {
        Task<CustomResult<PageResult<CategoryOutputModel>>> GetCategories(int size = 10, int index = 0);
    }

    public class RestaurantsFoodsGateway : IRestaurantsFoodsGateway
    {
        public async Task<CustomResult<PageResult<CategoryOutputModel>>> GetCategories(int size = 10, int index = 0)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7132/api/v1/categories?size=10&index=0");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<CustomResult<PageResult<CategoryOutputModel>>>(responseJson, options)!;
        }
    }
}
