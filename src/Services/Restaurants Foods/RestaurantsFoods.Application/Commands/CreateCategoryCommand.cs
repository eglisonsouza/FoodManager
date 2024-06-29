using FoodManager.Core.Mediator.Messages;

namespace RestaurantsFoods.Application.Commands
{
    public class CreateCategoryCommand : Command
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public CreateCategoryCommand(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
