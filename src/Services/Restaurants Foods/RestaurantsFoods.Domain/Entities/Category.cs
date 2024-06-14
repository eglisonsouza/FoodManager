using FoodManager.Core.DomainObjects;

namespace RestaurantsFoods.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }

        protected Category()
        {
        }

        public Category(string name, string imageUrl) : base()
        {
            Name = name;
            ImageUrl = imageUrl;

            Validate();
        }

        private void Validate()
        {
            if (ImageUrl == null)
            {
                throw new DomainException("ImageUrl cannot be null");
            }

            if (Name == null)
            {
                throw new DomainException("Name cannot be null");
            }
        }
    }
}