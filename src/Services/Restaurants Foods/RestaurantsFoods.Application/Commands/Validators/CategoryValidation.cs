using FluentValidation;

namespace RestaurantsFoods.Application.Commands.Validators
{
    public class CategoryValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CategoryValidation()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is not null or empty");

            RuleFor(p => p.ImageUrl)
               .NotNull()
               .NotEmpty()
               .WithMessage("ImageUrl is not null or empty");
        }
    }
}
