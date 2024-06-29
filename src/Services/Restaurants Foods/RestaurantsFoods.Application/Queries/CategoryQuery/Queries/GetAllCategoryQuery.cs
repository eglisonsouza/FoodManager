using FoodManager.Core.Mediator.Messages;

namespace RestaurantsFoods.Application.Queries.CategoryQuery.Queries
{
    public class GetAllCategoryQuery : Command
    {
        public int Size { get; set; }
        public int Index { get; set; }

        public GetAllCategoryQuery(int size, int index)
        {
            Size = size;
            Index = index;
        }
    }
}
